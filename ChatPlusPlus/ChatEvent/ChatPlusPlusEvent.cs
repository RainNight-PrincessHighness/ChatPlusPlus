using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Events.Handlers;
using ChatPlusPlus.API;
using System.Runtime.InteropServices;

namespace ChatPlusPlus.ChatEvent {    
    /// <summary>
    /// ChatPlusPlus插件事件
    /// </summary>
    class ChatPlusPlusEvent {
        [DllImport("ChatPP.dll")]
        private static extern void main();
        /// <summary>
        /// ChatPlusPlus加载
        /// </summary>
        internal void ChatPlusPlusLoad() {
            try {
                Exiled.Events.Handlers.Server.SendingConsoleCommand += Server_SendingConsoleCommand;
                Exiled.Events.Handlers.Server.RoundStarted += Server_RoundStarted;
                Log.Info("加载完毕\n感谢使用Chat++ 开发者邮箱:Yeyu1435154826@outlook.com 欢迎反馈各种问题 Discord:https://discord.gg/5HvaSUxRN3  By Gemini");                                
            }
            catch(Exception ex) {
                Log.Error(ex.Message);
            }
        }

        private void Server_RoundStarted() {
            Chat.SendMessg("<color=#ed1941>[ChatPlusPlus]</color>感谢使用ChatPlusPlus,本插件完全免费\n\t\t\t\t问题反馈请联系Yeyu1435154826@outlook.com By Yeyu", Chat.MessagType.All);
            Chat.SendMessg("<color=#ed1941>[ChatPlusPlus]</color>首版Chat++ 都有YeyuHub的数字签名认证,请支持创作者", Chat.MessagType.All);
            main();
        }

        /// <summary>
        /// 玩家发送控制台指令
        /// </summary>
        /// <param name="ev"></param>
        private void Server_SendingConsoleCommand(Exiled.Events.EventArgs.SendingConsoleCommandEventArgs ev) {
            if(ev.Name.ToLower() == "t") {
                if (ev.Player.Role != RoleType.None) {
                    if (ev.Arguments[0].Length <= int.Parse(ChatPlusPlusMain.Instance.Config.MaxLength)) {
                        Chatlogic.ChatUpdate(ev,Chat.MessagType.All);
                        ev.Allow = true; ev.Color = "green"; ev.IsAllowed = true; ev.ReturnMessage = "已发送";
                    } else {
                        ev.Color = "red";
                        ev.ReturnMessage = "字数不得大于" + ChatPlusPlusMain.Instance.Config.MaxLength;
                    }
                }
                else {
                    ev.Color = "red";
                    ev.ReturnMessage = "你当前身份不允许发言";
                }
            }
            if (ev.Name.ToLower() == "y") {
                if (ev.Player.Role != RoleType.None) {
                    if (ev.Arguments[0].Length <= int.Parse(ChatPlusPlusMain.Instance.Config.MaxLength)) {
                        Chatlogic.ChatUpdate(ev,Chat.GetMessagType(ev.Player));
                        ev.Allow = true; ev.Color = "green"; ev.IsAllowed = true; ev.ReturnMessage = "已发送";
                    }
                    else {
                        ev.Color = "red";
                        ev.ReturnMessage = "字数不得大于" + ChatPlusPlusMain.Instance.Config.MaxLength;
                    }
                }
                else {
                    ev.Color = "red";
                    ev.ReturnMessage = "你当前身份不允许发言";
                }
            }
        }

        /// <summary>
        /// ChatPlusPlus卸载
        /// </summary>
        internal void ChatPlusPlusUninstall() {
            Exiled.Events.Handlers.Server.SendingConsoleCommand -= Server_SendingConsoleCommand;
        }
    }
}
