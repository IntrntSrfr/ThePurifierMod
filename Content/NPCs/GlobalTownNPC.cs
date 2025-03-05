using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThePurifier.Content.Items;
using static Terraria.ModLoader.ModContent;

namespace ThePurifier.Content.NPCs
{
    public class ThePurifierGlobalNPC : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            int type = shop.NpcType;
            if (type == NPCID.Merchant)
            {
                shop.Add(ItemType<TheSwoerd>());
            }
        }
    }
}
