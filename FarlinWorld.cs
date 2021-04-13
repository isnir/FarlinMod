using farlinMod.Items.Weapons.Melee;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace farlinMod
{
    public class FarlinWorld : ModWorld
    {	
		public override void PostWorldGen()
		{
			// How place some items in Chests
			int[] itemsToPlaceInDungeonChests = { ModContent.ItemType<Spear_19>()};
			int itemsToPlaceInDungeonChestsChoice = 0;

			int[] itemsToPlaceInIceChests = { ModContent.ItemType<Spear_16>() };
			int itemsToPlaceInIceChestsChoice = 0;

			int[] itemsToPlaceInDesertChests = { ModContent.ItemType<Sword_01>()};
			int itemsToPlaceInDesertChestsChoice = 0;		

			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
			
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 3th chest is the Locked Gold Chest. Since we are counting from 0, this is where 2 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 2 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 2; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.BlueMoon && Main.rand.NextFloat() < .50f)
						{
							// Item placiment approach In case of multiple items.
							// Cyclical approach: chest.item[inventoryIndex].SetDefaults(itemsToPlaceInDungeonChests[itemsToPlaceInDungeonChestsChoice]);
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInDungeonChests));

							//Place approach in the following line
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInDungeonChests[itemsToPlaceInDungeonChestsChoice]);
							itemsToPlaceInDungeonChestsChoice = (itemsToPlaceInDungeonChestsChoice + 1) % itemsToPlaceInDungeonChests.Length;
							
							break;
						}
					}
				}

				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 11 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 2; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.IceBoomerang || chest.item[inventoryIndex].type == ItemID.IceBlade && Main.rand.NextFloat() < .50f)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInIceChests[itemsToPlaceInIceChestsChoice]);
							itemsToPlaceInIceChestsChoice = (itemsToPlaceInIceChestsChoice + 1) % itemsToPlaceInIceChests.Length;

							break;
						}
					}
				}				
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 1 * 36)
				{					
					for (int inventoryIndex = 0; inventoryIndex < 20; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.AngelStatue && Main.tile[chest.x, chest.y -1].type == TileID.Sandstone || Main.tile[chest.x, chest.y -1].type == TileID.Sand && Main.rand.NextFloat() < .50f)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInDesertChests[itemsToPlaceInDesertChestsChoice]);
							itemsToPlaceInDesertChestsChoice = (itemsToPlaceInDesertChestsChoice + 1) % itemsToPlaceInDesertChests.Length;

							break;
						}
						if (chest.item[inventoryIndex].type == ItemID.AngelStatue && Main.tile[chest.x, chest.y -1].type == TileID.SandstoneBrick)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInDesertChests[itemsToPlaceInDesertChestsChoice]);
							itemsToPlaceInDesertChestsChoice = (itemsToPlaceInDesertChestsChoice + 1) % itemsToPlaceInDesertChests.Length;

							break;
						}
					}
				}
			}
		}


    }
}
