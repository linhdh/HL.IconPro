﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;
using HL.MVVM;

namespace HL.IconPro.MVVM.Models
{
    class FrameModel : ModelBase
    {
        #region Constructors
        public FrameModel(BitmapFrame Frame, BitmapDecoder Decoder)
        {
            _Frame = Frame;
            _PixelFormat = _Frame.Format;
            _Size = new Size(_Frame.PixelWidth, _Frame.PixelHeight);
            if (Decoder != null)
            {
                if (Decoder.CodecInfo.FriendlyName.ToLower().Contains("png"))
                    _Type = IconFrameModelType.PNG;
                else
                    _Type = IconFrameModelType.Bitmap;
            }
            else
                _Type = IconFrameModelType.Bitmap;
            if (Frame.Palette == null)
                _PixelFormat = PixelFormats.Bgra32;
            else
            {
                if (Frame.Palette.Colors.Count == 16)
                    _PixelFormat = PixelFormats.Indexed4;
                else if (Frame.Palette.Colors.Count == 256)
                    _PixelFormat = PixelFormats.Indexed8;
            }
        }
        #endregion

        #region Destructors

        #endregion

        #region Fields
        private BitmapSource _Frame;
        private Size _Size;
        private PixelFormat _PixelFormat;
        private IconFrameModelType _Type;

        private ushort _HotspotX;
        private ushort _HotspotY;
        #endregion

        #region Properties
        public BitmapSource Frame
        {
            get
            {
                return _Frame;
            }
        }
        public Size Size
        {
            get
            {
                return _Size;
            }
        }
        public PixelFormat PixelFormat
        {
            get
            {
                return _PixelFormat;
            }
        }

        public IconFrameModelType Type
        {
            get { return _Type; }
        }

        public new string ToString
        {
            get
            {
                return string.Format("({0}) - {1} BPP", new object[] { Size.ToString(), PixelFormat.BitsPerPixel });
            }
        }

        public ushort HotspotX { get => _HotspotX; set => SetField(ref _HotspotX, value); }
        public ushort HotspotY { get => _HotspotY; set => SetField(ref _HotspotY, value); }
        #endregion

        #region Procedures

        #endregion

        #region Static

        #endregion

        #region Others

        #endregion
    }
    public enum IconFrameModelType
    {
        Bitmap,
        PNG
    };
}
