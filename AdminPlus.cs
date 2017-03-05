using System;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Plugins;

namespace Oxide.Plugins
{
    [Info("AdminPlus", "Jakkee", "1.0")]
    public class AdminPlus : RustLegacyPlugin
    {
        private string PluginName = "AdminPlus";
        const string PermCanUseCommand = "adminplus.use";

        [ChatCommand("admin")]
        void Command_Admin(NetUser netuser, string command, string[] args)
        {
            if (permission.UserHasPermission(netuser.userID.ToString(), PermCanUseCommand))
            {
                if (args.Length == 1)
                {
                    Inventory inv = netuser.playerClient.rootControllable.idMain.GetComponent<Inventory>();
                    if (args[0] == "on")
                    {
                        inv.RemoveItem(36);
                        inv.RemoveItem(37);
                        inv.RemoveItem(38);
                        inv.RemoveItem(39);
                        GiveItem(netuser, "Invisible Helmet", 1, 36);
                        GiveItem(netuser, "Invisible Vest", 1, 37);
                        GiveItem(netuser, "Invisible Pants", 1, 38);
                        GiveItem(netuser, "Invisible Boots", 1, 39);
                        rust.SendChatMessage(netuser, PluginName, "You're now invisible!");
                    }
                    else if (args[0] == "off")
                    {
                        inv.RemoveItem(36);
                        inv.RemoveItem(37);
                        inv.RemoveItem(38);
                        inv.RemoveItem(39);
                        rust.SendChatMessage(netuser, PluginName, "You're now visible!");
                    }
                    else if (args[0] == "wood")
                    {
                        GiveItem(netuser, "Wood Pillar", 250);
                        GiveItem(netuser, "Wood Foundation", 250);
                        GiveItem(netuser, "Wood Wall", 250);
                        GiveItem(netuser, "Wood Doorway", 250);
                        GiveItem(netuser, "Wood Window", 250);
                        GiveItem(netuser, "Wood Stairs", 250);
                        GiveItem(netuser, "Wood Ramp", 250);
                        GiveItem(netuser, "Wood Ceiling", 250);
                        GiveItem(netuser, "Metal Door", 15);
                        GiveItem(netuser, "Metal Window Bars", 15);
                        rust.SendChatMessage(netuser, PluginName, "Wood building parts spawned!");
                    }
                    else if (args[0] == "metal")
                    {
                        GiveItem(netuser, "Metal Pillar", 250);
                        GiveItem(netuser, "Metal Foundation", 250);
                        GiveItem(netuser, "Metal Wall", 250);
                        GiveItem(netuser, "Metal Doorway", 250);
                        GiveItem(netuser, "Metal Window", 250);
                        GiveItem(netuser, "Metal Stairs", 250);
                        GiveItem(netuser, "Metal Ramp", 250);
                        GiveItem(netuser, "Metal Ceiling", 250);
                        GiveItem(netuser, "Metal Door", 15);
                        GiveItem(netuser, "Metal Window Bars", 15);
                        rust.SendChatMessage(netuser, PluginName, "Metal building parts spawned!");
                    }
                    else if (args[0] == "weapons")
                    {
                        GiveItem(netuser, "Bolt Action Rifle", 1);
                        GiveItem(netuser, "M4", 1);
                        GiveItem(netuser, "MP5A4", 1);
                        GiveItem(netuser, "9mm Pistol", 1);
                        GiveItem(netuser, "P250", 1);
                        GiveItem(netuser, "Shotgun", 1);
                        GiveItem(netuser, "556 Ammo", 250);
                        GiveItem(netuser, "9mm Ammo", 250);
                        GiveItem(netuser, "Shotgun Shells", 250);
                        rust.SendChatMessage(netuser, PluginName, "Weapons and Ammo spawned!");
                    }
                    else if (args[0] == "kevlar")
                    {
                        inv.RemoveItem(36);
                        inv.RemoveItem(37);
                        inv.RemoveItem(38);
                        inv.RemoveItem(39);
                        GiveItem(netuser, "kevlar Helmet", 1, 36);
                        GiveItem(netuser, "kevlar Vest", 1, 37);
                        GiveItem(netuser, "kevlar Pants", 1, 38);
                        GiveItem(netuser, "kevlar Boots", 1, 39);
                        rust.SendChatMessage(netuser, PluginName, "Kevlar spawned!");
                        rust.SendChatMessage(netuser, PluginName, "I hope you have a legitimate reason why need this!");
                    }
                    else if (args[0] == "uber")
                    {
                        GiveItem(netuser, "Uber Hatchet", 1);
                        GiveItem(netuser, "Uber Hunting Bow", 1);
                        GiveItem(netuser, "Arrow", 40);
                        rust.SendChatMessage(netuser, PluginName, "Uber items spawned!");
                    }
                    else if (args[0] == "clear")
                    {
                        inv.Clear();
                        rust.SendChatMessage(netuser, PluginName, "Inventory cleared!");
                    }
                    else
                    {
                        rust.SendChatMessage(netuser, PluginName, "/admin " + args[0] + "is unknown, Try a different command!");
                    }
                }
                else
                {
                    rust.SendChatMessage(netuser, PluginName, "[color green]/admin [on / off][color white] - Invisible suit");
                    rust.SendChatMessage(netuser, PluginName, "[color green]/admin metal[color white] - Spawns metal building parts");
                    rust.SendChatMessage(netuser, PluginName, "[color green]/admin wood[color white] - Spawns wood building parts");
                    rust.SendChatMessage(netuser, PluginName, "[color green]/admin uber[color white] - Spawns uber items");
                    rust.SendChatMessage(netuser, PluginName, "[color green]/admin kevlar[color white] - Spawns kevlar");
                    rust.SendChatMessage(netuser, PluginName, "[color green]/admin weapons[color white] - Gives you weapons + Ammo");
                    rust.SendChatMessage(netuser, PluginName, "[color green]/admin clear[color white] - Clears your inventory");
                    rust.SendChatMessage(netuser, PluginName, "[color green]/admin doors[color white] - Toggles you to open all doors");
                }
            }
            else
            {
                rust.SendChatMessage(netuser, PluginName, "You do not have permission to use this command!");
            }
        }

        ItemDataBlock GetItemDataBlock(string itemname)
        {
            ItemDataBlock datablock = DatablockDictionary.GetByName(itemname);
            return datablock;
        }

        private void GiveItem(NetUser netuser, string itemname, int amount, int slot = null)
        {
            if (slot == null)
            {
                inv.AddItemAmount(GetItemDataBlock("itemname"), amount);
            }
            else
            {
                inv.AddItem(GetItemDataBlock("itemname"), slot, amount);
            }
        }
    }
}