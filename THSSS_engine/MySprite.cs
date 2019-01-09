﻿using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public class MySprite
  {
    public Sprite sprite { get; set; }

    public MySprite(Device device)
    {
      this.sprite = new Sprite(device);
    }

    public void Begin(SpriteFlags flags)
    {
      this.sprite.Begin(flags);
    }

    public void End()
    {
      this.sprite.End();
    }

    public void Draw2D(
      Texture srcTexture,
      PointF rotationCenter,
      float rotationAngle,
      PointF position,
      Color color)
    {
      Vector3 vector3_1 = new Vector3(rotationCenter.X, rotationCenter.Y, 0.0f);
      Vector3 vector3_2 = new Vector3(position.X, position.Y, 0.0f);
      Color4 color1 = new Color4(color);
      Vector2 vector2 = new Vector2(position.X, position.Y);
      this.sprite.Transform = Matrix.Transformation2D(vector2, 0.0f, new Vector2(1f, 1f), vector2, rotationAngle, new Vector2(0.0f, 0.0f));
      this.sprite.Draw(srcTexture, new Vector3?(vector3_1), new Vector3?(vector3_2), color1);
      this.sprite.Transform = Matrix.Identity;
    }

    public void Draw2D(
      Texture srcTexture,
      Rectangle srcRectangle,
      SizeF destinationSize,
      PointF position,
      Color color)
    {
      Vector3 vector3 = new Vector3(position.X, position.Y, 0.0f);
      Color4 color1 = new Color4(color);
      Vector2 vector2 = new Vector2(position.X, position.Y);
      Vector2 scaling = new Vector2(destinationSize.Width / (float) srcRectangle.Width, destinationSize.Height / (float) srcRectangle.Height);
      this.sprite.Transform = Matrix.Transformation2D(vector2, 0.0f, scaling, vector2, 0.0f, new Vector2(0.0f, 0.0f));
      this.sprite.Draw(srcTexture, new Rectangle?(srcRectangle), new Vector3?(new Vector3(0.0f, 0.0f, 0.0f)), new Vector3?(vector3), color1);
      this.sprite.Transform = Matrix.Identity;
    }

    public void Draw2D(
      Texture srcTexture,
      Rectangle srcRectangle,
      SizeF destinationSize,
      PointF rotationCenter,
      float rotationAngle,
      PointF position,
      Color color)
    {
      Vector3 vector3_1 = new Vector3(rotationCenter.X, rotationCenter.Y, 0.0f);
      Vector3 vector3_2 = new Vector3(position.X, position.Y, 0.0f);
      Color4 color1 = new Color4(color);
      Vector2 vector2_1 = new Vector2(rotationCenter.X, rotationCenter.Y);
      Vector2 vector2_2 = new Vector2(position.X, position.Y);
      Vector2 vector2_3 = vector2_1 + vector2_2;
      Vector2 scaling = new Vector2(destinationSize.Width / (float) srcRectangle.Width, destinationSize.Height / (float) srcRectangle.Height);
      this.sprite.Transform = Matrix.Transformation2D(vector2_2, 0.0f, scaling, vector2_2, rotationAngle, new Vector2(0.0f, 0.0f));
      this.sprite.Draw(srcTexture, new Rectangle?(srcRectangle), new Vector3?(vector3_1), new Vector3?(vector3_2), color1);
      this.sprite.Transform = Matrix.Identity;
    }

    public void Draw2D(
      TextureObject txtureObject,
      float scale,
      float rotationAngle,
      PointF position,
      int transpanrent)
    {
      this.Draw2D(txtureObject, scale, rotationAngle, position, Color.FromArgb(transpanrent, Color.White));
    }

    public void Draw2D(
      TextureObject txtureObject,
      float scale,
      float rotationAngle,
      PointF position,
      Color color)
    {
      this.Draw2D(txtureObject, scale, rotationAngle, position, txtureObject.RotatingCenter, color);
    }

    public void Draw2D(
      TextureObject txtureObject,
      float scale,
      float rotationAngle,
      PointF position,
      PointF rotationCenter,
      Color color)
    {
      this.Draw2D(txtureObject, scale, rotationAngle, position, rotationCenter, color, false);
    }

    public void Draw2D(
      TextureObject txtureObject,
      float scale,
      float rotationAngle,
      PointF position,
      PointF rotationCenter,
      Color color,
      bool mirrored)
    {
      this.Draw2D(txtureObject, scale, scale, rotationAngle, position, rotationCenter, color, mirrored);
    }

    public void Draw2D(
      TextureObject txtureObject,
      float scaleX,
      float scaleY,
      float rotationAngle,
      PointF position,
      Color color,
      bool mirrored)
    {
      this.Draw2D(txtureObject, scaleX, scaleY, rotationAngle, position, txtureObject.RotatingCenter, color, mirrored);
    }

    public void Draw2D(
      TextureObject txtureObject,
      float scaleX,
      float scaleY,
      float rotationAngle,
      PointF position,
      PointF rotationCenter,
      Color color,
      bool mirrored)
    {
      Vector3 vector3_1 = new Vector3(rotationCenter.X, rotationCenter.Y, 0.0f);
      Vector3 vector3_2 = new Vector3(position.X, position.Y, 0.0f);
      Color4 color1 = new Color4(color);
      Vector2 vector2_1 = new Vector2(rotationCenter.X, rotationCenter.Y);
      Vector2 vector2_2 = new Vector2(position.X, position.Y);
      Vector2 vector2_3 = vector2_1 + vector2_2;
      Vector2 scaling = mirrored ? new Vector2(-scaleX, scaleY) : new Vector2(scaleX, scaleY);
      this.sprite.Transform = Matrix.Transformation2D(vector2_2, 0.0f, scaling, vector2_2, rotationAngle, new Vector2(0.0f, 0.0f));
      this.sprite.Draw(txtureObject.TXTure, new Rectangle?(txtureObject.PosRect), new Vector3?(vector3_1), new Vector3?(vector3_2), color1);
      this.sprite.Transform = Matrix.Identity;
    }

    public void Dispose()
    {
      this.sprite.Dispose();
    }
  }
}
