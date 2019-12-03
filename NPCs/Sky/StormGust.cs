using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Critters.NPCs.Sky
{
    public class StormGust : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Gust");
			Main.npcFrameCount[npc.type] = 8;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 64;  
			npc.lifeMax = 5;	 
            npc.defense = 0;  
            npc.width = 20;
            npc.height = 34;
			npc.npcSlots = 0;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("StormGustItem");
						banner = npc.type;
			bannerItem = mod.ItemType("StormGustBanner");
			npc.damage = 0;
            npc.noGravity = true;
            npc.noTileCollide = false;
			npc.dontCountMe = true;
			npc.HitSound = SoundID.NPCHit11;
			npc.DeathSound = SoundID.NPCDeath15;
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
            var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
                             drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            CrittersUtility.DrawNPCGlowMask(spriteBatch, npc, ModContent.GetTexture("Critters/NPCs/Masks/StormGust_Glow"));
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			if (Main.rand.NextFloat() < 0.131579f)
			{
				Dust dust;
				Vector2 position = npc.Center;
				dust = Terraria.Dust.NewDustPerfect(position, 16, new Vector2(0f, 8.421053f), 0, new Color(100,150,255), 1.447368f);
				dust.noGravity = true;
				dust.fadeIn = 0.5526316f;
			}

        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				npc.position.X = npc.position.X + (float)(npc.width / 2);
				npc.position.Y = npc.position.Y + (float)(npc.height / 2);
				npc.width = 32;
				npc.height = 32;
				npc.position.X = npc.position.X - (float)(npc.width / 2);
				npc.position.Y = npc.position.Y - (float)(npc.height / 2);
				for (int num621 = 0; num621 < 20; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 203, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].noGravity = true;
					Main.dust[num622].velocity *= .1f;
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.ZoneRain  && spawnInfo.spawnTileY > Main.rockLayer  && !spawnInfo.player.ZoneSnow  ? 0.194f : 0f;
		}
		public override void NPCLoot ()
		{		
			/*if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Aurora_Bowl"), Main.rand.Next(1, 5));
			}*/
		}
		public override void FindFrame(int frameHeight)
		{
			const int Frame_1 = 0;
			const int Frame_2 = 1;
			const int Frame_3 = 2;
			const int Frame_4 = 3;
			const int Frame_5 = 4;
			const int Frame_6 = 5;
			const int Frame_7 = 6;
			const int Frame_8 = 7;
			
			npc.frameCounter++;
			if (npc.frameCounter < 4)
			{
				npc.frame.Y = Frame_1 * frameHeight;
			}
			else if (npc.frameCounter < 8)
			{
				npc.frame.Y = Frame_2 * frameHeight;
			}
			else if (npc.frameCounter < 12)
			{
				npc.frame.Y = Frame_3 * frameHeight;
			}
			else if (npc.frameCounter < 16)
			{
				npc.frame.Y = Frame_4 * frameHeight;
			}
			else if (npc.frameCounter < 20)
			{
				npc.frame.Y = Frame_5 * frameHeight;
			}
			else if (npc.frameCounter < 24)
			{
				npc.frame.Y = Frame_6 * frameHeight;
			}
			else if (npc.frameCounter < 28)
			{
				npc.frame.Y = Frame_7 * frameHeight;
			}
			else if (npc.frameCounter < 32)
			{
				npc.frame.Y = Frame_8 * frameHeight;
			}
			else
			{
				npc.frameCounter = 0;
			}
		}
    }
}