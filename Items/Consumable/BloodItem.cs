using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class BloodItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodlurker");
			Tooltip.SetDefault("'Deceptively cute, but quite menacing'");
		}


        public override void SetDefaults()
        {
            item.width = 20;
			item.height = 12;
            item.rare = 1;
			item.value = Item.sellPrice(0, 0, 6, 0);
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("Bloodlurker"));
            return true;
        }

        }
}
