using SlimDX.Direct3D9;

namespace Shooting {
    public class ScreenTexManager {
        public ScreenTexture[] ScreenTex { get; private set; }
        private int ScreenLevel { get; set; }
        public Texture RenderTexture => ScreenTex[ScreenLevel].renderTexture;
        public ScreenTexManager(Device DeviceMain) {
            ScreenTex=new ScreenTexture[5];
            for(int index = 0;index<ScreenTex.Length;++index) {
                ScreenTex[index]=new ScreenTexture(DeviceMain,640,480);
            }
        }
        public void Begin() => ScreenTex[ScreenLevel++].Begin();
        public void End() => ScreenTex[--ScreenLevel].End();
        public void Reset() {

            for(int index = 0;index<ScreenTex.Length;++index) {
                if(ScreenTex[index]!=null) {
                    ScreenTex[index].Reset();
                }
            }
        }
        public void Dispose() {
            for(int index = 0;index<ScreenTex.Length;++index) {
                if(ScreenTex[index]!=null) {
                    ScreenTex[index].Dispose();
                }
            }
        }
    }
}
