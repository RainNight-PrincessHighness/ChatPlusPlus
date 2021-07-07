using ChatPlusPlus.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Hints;
using LiteNetLib.Utils;

namespace ChatPlusPlus {
    internal static class Chatlogic {
        internal static string ReturnColorName(Player ev) {
            string YName = "";
            switch (ev.Role) {
                case RoleType.ClassD:
                    YName = $"<color=#FF8E00>{ev.Nickname}</color>";
                    break;
                case RoleType.ChaosInsurgency:
                    //#008f1e
                    YName = $"<color=#008f1e>{ev.Nickname}</color>";
                    break;
                case RoleType.FacilityGuard:
                    //918f8d
                    YName = $"<color=#918f8d>{ev.Nickname}</color>";
                    break;
                case RoleType.NtfCadet:
                    //4cd1e1
                    YName = $"<color=#4cd1e1>{ev.Nickname}</color>";
                    break;
                case RoleType.NtfCommander:
                    //0125ff
                    YName = $"<color=#0125ff>{ev.Nickname}</color>";
                    break;
                case RoleType.NtfLieutenant:
                    //#0096FF
                    YName = $"<color=#0096FF>{ev.Nickname}</color>";
                    break;
                case RoleType.NtfScientist:
                    //#0096FF
                    YName = $"<color=#0096FF>{ev.Nickname}</color>";
                    break;
                case RoleType.Scientist:
                    //#FFFF7CFF
                    YName = $"<color=#FFFF7CFF>{ev.Nickname}</color>";
                    break;
                case RoleType.Scp049:
                    //#f00
                    YName = $"<color=#f00>{ev.Nickname}</color>";
                    break;
                case RoleType.Scp0492:
                    YName = $"<color=#f00>{ev.Nickname}</color>";
                    break;
                case RoleType.Scp079:
                    YName = $"<color=#f00>{ev.Nickname}</color>";
                    break;
                case RoleType.Scp096:
                    YName = $"<color=#f00>{ev.Nickname}</color>";
                    break;
                case RoleType.Scp106:
                    YName = $"<color=#f00>{ev.Nickname}</color>";
                    break;
                case RoleType.Scp173:
                    YName = $"<color=#f00>{ev.Nickname}</color>";
                    break;
                case RoleType.Scp93953:
                    YName = $"<color=#f00>{ev.Nickname}</color>";
                    break;
                case RoleType.Scp93989:
                    YName = $"<color=#f00>{ev.Nickname}</color>";
                    break;
                case RoleType.Spectator:
                    YName = $"{ev.Nickname}";
                    break;
                case RoleType.Tutorial:
                    //46ce3b
                    YName = $"<color=#46ce3b>{ev.Nickname}</color>";
                    break;
            }
            return YName;
        }
        internal static string Up(Player player) {
            List<Chat.ChatInfo> Chats = Chat.chatInfos; 
            string body = "\n\n\n\n\n<size=15>";
            foreach (Chat.ChatInfo chatInfo in Chats) {
                if (chatInfo.MessagType != Chat.MessagType.All) {
                    if (chatInfo.MessagType != Chat.MessagType.Target) {
                        if (Chat.GetMessagType(player) != chatInfo.MessagType) {
                            Chats.Remove(chatInfo);
                        }
                    }
                    else if(chatInfo.Player != player){                        
                            Chats.Remove(chatInfo);                        
                    }
                }
            }
            foreach (Chat.ChatInfo chatinfo in Chats) {                
                body += "\t\t\t\t" + chatinfo.Messg + Environment.NewLine;                             
                if (body.Length < int.Parse(ChatPlusPlusMain.Instance.Config.MaxLength)) {
                    for(int i = 0;i < (int.Parse(ChatPlusPlusMain.Instance.Config.MaxLength) - body.Length);i++) {
                        body += " ";
                    }
                } 
            }           
            body += "</size>";
            return body;
        }
        /// <summary>
        /// 聊天内容更新
        /// </summary>
        /// 
        internal static void ChatUpdate(SendingConsoleCommandEventArgs ev, Chat.MessagType messagType) {
            string Con = "";
            foreach(string a in ev.Arguments) {
                Con += a + " ";
            }
            Chat.SendMessg($"[{ReturnColorName(ev.Player)}]{Con}", messagType);
            foreach (Player player in Player.List.ToList()) {                          
                        player.ShowHint("", 1);
                        player.ShowHint(Up(player), 10);
            }
        }
        internal static void ChatUpdate() {
            foreach (Player player in Player.List.ToList()) {
                foreach (Chat.ChatInfo chatInfo in Chat.chatInfos) {
                    if (chatInfo.MessagType == Chat.GetMessagType(player)) {
                        player.ShowHint("", 1);
                        player.ShowHint(Up(player), 10);
                    }
                    else if (chatInfo.MessagType == Chat.MessagType.All) {
                        player.ShowHint("", 1);
                        player.ShowHint(Up(player), 10);
                    }
                }
            }
        }
    }
}
