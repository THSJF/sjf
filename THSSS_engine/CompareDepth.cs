using System.Collections.Generic;

namespace Shooting {
    public class CompareDepth:IComparer<BaseParticle3D> {
        public int Compare(BaseParticle3D p1,BaseParticle3D p2) => (int)(p1.Depth*10.0-p2.Depth*10.0);
    }
}
