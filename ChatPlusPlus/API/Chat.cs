using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPlusPlus.API {
    public static class Chat {
        /// <summary>
        /// 消息合集
        /// </summary>
        internal static List<ChatInfo> chatInfos = new List<ChatInfo>();
        public static void SendMessg(string messg, MessagType messagType) {
           if(chatInfos.Count >= 7) {
                chatInfos.Clear();
           }     
           chatInfos.Add(new ChatInfo(messg, messagType));
           Chatlogic.ChatUpdate();
        }
        public static void SendMessgToPlayer(string messg,Player player) {
            if (chatInfos.Count >= 7) {
                chatInfos.Clear();
            }
            chatInfos.Add(new ChatInfo(messg,Chat.MessagType.Target,player));
            Chatlogic.ChatUpdate();
        }
        public static void SendMessg(ChatInfo chatInfo) {
            if (chatInfos.Count >= 7) {
                chatInfos.Clear();
            }
            chatInfos.Add(chatInfo);
            Chatlogic.ChatUpdate();
        }
        /// <summary>
        /// 消息包
        /// </summary>
        public class ChatInfo {
            public ChatInfo(string messag,MessagType messagType) {
                Messg = messag;
                MessagType = messagType;
            }
            public ChatInfo(string messag, MessagType messagType,Player player) {
                Messg = messag;
                MessagType = messagType;
                Player = player;
            }
            /// <summary>
            /// 消息内容
            /// </summary>
            public string Messg { get; set; }
            /// <summary>
            /// 消息类型
            /// </summary>
            public MessagType MessagType { get; set; }
            public Player Player { get; set; }
        }
        public static MessagType GetMessagType(Player player) {
            switch(Grup.GetGrup(player)) {
                case Grup.GrupClass.ClassD_ChaosInsurgency:
                    return MessagType.ClassD_ChaosInsurgency;                    
                case Grup.GrupClass.Ntf_Scientist:
                    return MessagType.Ntf_Scientist;
                case Grup.GrupClass.Scp:
                    return MessagType.Scp;
                case Grup.GrupClass.Spectator:
                    return MessagType.Spectator;
                case Grup.GrupClass.None:
                    return MessagType.None;
            }
            return MessagType.None;
        }
        public enum MessagType {
            None = 0,
            Scp = 1,
            Ntf_Scientist = 2,
            ClassD_ChaosInsurgency = 3,
            Spectator = 4,
            Target = 5,
            All = 6
        }
        /// <summary>
        /// 玩家阵营类
        /// </summary>
        internal static class Grup {
            public enum GrupClass {
                ClassD_ChaosInsurgency = 0,
                Ntf_Scientist = 1,
                Scp = 2,
                Spectator = 3,
                None = 4
            }
            public static GrupClass GetGrup(Player player) {

                GrupClass grup = GrupClass .None;
                switch (player.Role) {
                    case RoleType.None:
                        grup = GrupClass.None;
                        break;
                    case RoleType.ClassD:
                        grup = GrupClass.ClassD_ChaosInsurgency;
                        break;
                    case RoleType.ChaosInsurgency:
                        grup = GrupClass.ClassD_ChaosInsurgency;
                        break;
                    case RoleType.FacilityGuard:
                        grup = GrupClass.Ntf_Scientist;
                        break;
                    case RoleType.NtfCadet:
                        grup = GrupClass.Ntf_Scientist;
                        break;
                    case RoleType.NtfCommander:
                        grup = GrupClass.Ntf_Scientist;
                        break;
                    case RoleType.NtfLieutenant:
                        grup = GrupClass.Ntf_Scientist;
                        break;
                    case RoleType.NtfScientist:
                        grup = GrupClass.Ntf_Scientist;
                        break;
                    case RoleType.Scientist:
                        grup = GrupClass.Ntf_Scientist;
                        break;
                    case RoleType.Scp049:
                        grup = GrupClass.Scp;
                        break;
                    case RoleType.Scp0492:
                        grup = GrupClass.Scp;
                        break;
                    case RoleType.Scp079:
                        grup = GrupClass.Scp;
                        break;
                    case RoleType.Scp096:
                        grup = GrupClass.Scp;
                        break;
                    case RoleType.Scp106:
                        grup = GrupClass.Scp;
                        break;
                    case RoleType.Scp173:
                        grup = GrupClass.Scp;
                        break;
                    case RoleType.Scp93953:
                        grup = GrupClass.Scp;
                        break;
                    case RoleType.Scp93989:
                        grup = GrupClass.Scp;
                        break;
                    case RoleType.Spectator:
                        grup = GrupClass.Spectator;
                        break;
                    case RoleType.Tutorial:
                        grup = GrupClass.Spectator;
                        break;
                }
                return grup;
            }
        }
    }
}
