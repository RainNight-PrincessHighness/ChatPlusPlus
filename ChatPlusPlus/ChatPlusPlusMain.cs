using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Enums;
using System.ComponentModel;

namespace ChatPlusPlus
{
    /// <summary>
    /// 继承类
    /// </summary>
    public class ChatPlusPlusMain : Plugin<ChatPlusPlusConfig> {
        private static readonly Lazy<ChatPlusPlusMain> LazyInstance = new Lazy<ChatPlusPlusMain>(() => new ChatPlusPlusMain());       
        public static ChatPlusPlusMain Instance => LazyInstance.Value;
        private ChatEvent.ChatPlusPlusEvent ChatPlusPlusEvent;
        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.Last;
        /// <inheritdoc/>
        public override void OnEnabled() {
            base.OnEnabled();
            ChatPlusPlusEvent = new ChatEvent.ChatPlusPlusEvent();
            ChatPlusPlusEvent.ChatPlusPlusLoad();
        }
        /// <inheritdoc/>
        public override void OnDisabled() {
            base.OnDisabled();
            ChatPlusPlusEvent.ChatPlusPlusUninstall();
            ChatPlusPlusEvent = null;
        }

    }
    /// <summary>
    /// 插件配置
    /// </summary>
    public sealed class ChatPlusPlusConfig : Exiled.API.Interfaces.IConfig {
        /// <inheritdoc/>
        [Description("指定ChatPlusPlus插件是否启用")]
        public bool IsEnabled { get; set; } = true;
        /// <inheritdoc/>
        [Description("每次聊天最大字数 推荐<=15")]
        public string MaxLength { get; set; } = "15";
    }
}
