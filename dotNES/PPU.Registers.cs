﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNES
{
    partial class PPU
    {
        public class PPUFlags
        {
            /* PPUCTRL register */
            public bool NMIEnabled;
            public bool IsMaster;
            public bool TallSpritesEnabled;
            public int PatternTableAddress;
            public int SpriteTableAddress;
            public bool VRAMIncrementMode;
            public int NametableAddress;

            /* PPUMASK register */
            public bool GrayscaleEnabled;
            public bool DrawLeftBackground;
            public bool DrawLeftSprites;
            public bool DrawBackground;
            public bool DrawSprites;
            // Flipped for PAL/Dendy
            public bool EmphasizeRed;
            public bool EmphasizeGreen;
            public bool EmphasizeBlue;

            /* PPUSTATUS register */
            public bool VBlankStarted;
            public bool Sprite0Hit;
            public bool SpriteOverflow;
        }

        public PPUFlags F = new PPUFlags();

        public int PPUCTRL
        {
            get { throw new NotImplementedException(); }
            set
            {
                F.NMIEnabled = (value & 0x80) > 0;
                F.IsMaster = (value & 0x40) > 0;
                F.TallSpritesEnabled = (value & 0x20) > 0;
                F.PatternTableAddress = (value & 0x10) > 0 ? 0x1000 : 0x0000;
                F.SpriteTableAddress = (value & 0x08) > 0 ? 0x1000 : 0x0000;
                F.VRAMIncrementMode = (value & 0x04) > 0;
                F.NametableAddress = (value & 0x3) * 0x400 + 0x2000;
            }
        }

        public int PPUMASK
        {
            get { throw new NotImplementedException(); }
            set
            {
                F.GrayscaleEnabled = (value & 0x1) > 0;
                F.DrawLeftBackground = (value & 0x2) > 0;
                F.DrawLeftSprites = (value & 0x4) > 0;
                F.DrawBackground = (value & 0x8) > 0;
                F.DrawSprites = (value & 0x10) > 0;
                F.EmphasizeRed = (value & 0x20) > 0;
                F.EmphasizeGreen = (value & 0x40) > 0;
                F.EmphasizeBlue = (value & 0x80) > 0;
            }
        }

        public int PPUSTATUS
        {
            get
            {
                return (F.VBlankStarted.AsByte() << 7) |
                    (F.Sprite0Hit.AsByte() << 6) |
                    (F.SpriteOverflow.AsByte() << 5) |
                    (_lastWrittenRegister & 0x1F);
            }
            set { throw new NotImplementedException(); }
        }
    }
}