using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;


namespace Critters.Items.Plants
{
    public class GhostReedItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghost Reed");
			Tooltip.SetDefault("'The plant flickers in and out of existence'");
			CrittersGlowmask.AddGlowMask(item.type, "Critters/Glowmask/GhostReedItem");
		}


        public override void SetDefaults()
        {
           item.width = 18;
			item.height = 54;
            item.value = 6000;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("GhostReed");

        }
		 	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			if(!Main.dayTime)
			{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				ModContent.GetTexture("Critters/Glowmask/GhostReedItem"),
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale, 
				SpriteEffects.None, 
				0f
			);
			}
		}
    }
}
