using System;
using System.Drawing;

namespace Shooting {
    internal class CharacterName:BaseStoryItem {
        public CharacterName(StageDataPackage StageData,string textureName) : base(StageData) {
            Rectangle boundRect = BoundRect;
            double num1 = boundRect.Right-70;
            boundRect=BoundRect;
            double num2 = boundRect.Top+300;
            Position=new PointF((float)num1,(float)num2);
            Velocity=0.0f;
            Direction=Math.PI/2.0;
            TransparentValueF=0.0f;
            TxtureObject=TextureObjectDictionary[textureName];
            TransparentVelocityDictionary.Add(10,20f);
            TransparentVelocityDictionary.Add(210,-10f);
        }
    }
}
