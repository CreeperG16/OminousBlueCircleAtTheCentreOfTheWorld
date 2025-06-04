using OnixRuntime.Api;
using OnixRuntime.Plugin;
using OnixRuntime.Api.Rendering;
using OnixRuntime.Api.Maths;

namespace OminousBlueCircleAtTheCentreOfTheWorld {
    public class OminousBlueCircleAtTheCentreOfTheWorld : OnixPluginBase {
        public static OminousBlueCircleAtTheCentreOfTheWorld Instance { get; private set; } = null!;
        public static OminousBlueCircleAtTheCentreOfTheWorldConfig Config { get; private set; } = null!;

        public OminousBlueCircleAtTheCentreOfTheWorld(OnixPluginInitInfo initInfo) : base(initInfo) {
            Instance = this;
            // If you can clean up what the plugin leaves behind manually, please do not unload the plugin when disabling.
            base.DisablingShouldUnloadPlugin = false;
#if DEBUG
           // base.WaitForDebuggerToBeAttached();
#endif
        }

        protected override void OnLoaded() {
            Config = new OminousBlueCircleAtTheCentreOfTheWorldConfig(PluginDisplayModule);
            Onix.Events.Common.WorldRender += OnWorldRender;
        }

        protected override void OnEnabled() {}
        protected override void OnDisabled() {}

        protected override void OnUnloaded() {
            // Ensure every task or thread is stopped when this function returns.
            // You can give them base.PluginEjectionCancellationToken which will be cancelled when this function returns. 
            Console.WriteLine($"Plugin {CurrentPluginManifest.Name} unloaded!");
            Onix.Events.Common.WorldRender -= OnWorldRender;
        }

        private void OnWorldRender(RendererWorld gfx, float delta) {
            gfx.FillCircle(Vec2.Zero, ColorF.Blue, 6, 30);
        }
    }
}
