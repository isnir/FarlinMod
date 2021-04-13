using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace farlinMod
{
	public class farlinMod : Mod
	{
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Shadow Scale", new int[]
			{
		ItemID.ShadowScale,
		ItemID.TissueSample
			});
			RecipeGroup.RegisterGroup("Farlin:ShadowScale", group);
		}
	}
}