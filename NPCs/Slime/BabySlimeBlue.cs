using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Critters.NPCs.Slime
{
	public class BabySlimeBlue : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Blue Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 20;
			npc.height = 16;
			npc.damage = 0;
			npc.defense = 1000;
			npc.dontCountMe = true;
			npc.lifeMax = 3;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("BabySlimeBlue");
			npc.knockBackResist = .45f;
			npc.aiStyle = 1;
			npc.npcSlots = 0;
			npc.noGravity = false;
			aiType = NPCID.BlueSlime;
			npc.alpha = 40;
			animationType = NPCID.BlueSlime;
			banner = npc.type;
			bannerItem = mod.ItemType("BlueBannerItem");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				npc.position.X = npc.position.X + (float)(npc.width / 2);
				npc.position.Y = npc.position.Y + (float)(npc.height / 2);
				npc.width = 20;
				npc.height = 16;
				npc.position.X = npc.position.X - (float)(npc.width / 2);
				npc.position.Y = npc.position.Y - (float)(npc.height / 2);
				for (int num621 = 0; num621 < 10; num621++)
				{
					
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 33, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].noGravity = true;
					Main.dust[num622].velocity *= .1f;
					Main.dust[num622].noGravity = true;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num622].scale = 0.9f;
						Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
			}
		}
		public override void AI()
		{
			npc.spriteDirection = -npc.direction;
		}
		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, 1);
			}
		}
	}
}
