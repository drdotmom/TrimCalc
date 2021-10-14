using System;
using System.Collections.Generic;

namespace TrimCalc
{
    public class Trimsheet
    {
        public int Size;
        public int RowCount;
        public int Padding;
        public TrimParams[] Trims;

        public Trimsheet(int textureSize, int rowsCount, int padding)
        {
            Size = textureSize;
            RowCount = rowsCount;
            Padding = padding;
            var rowSize = (textureSize / RowCount) - (padding * 2);
            
            Trims = new TrimParams[RowCount];
            for (var i = 0; i < RowCount; i++)
            {
                Trims[i].Id = i;
                Trims[i].Corner = (i * rowSize) + (padding * (i + 1));
                Trims[i].Size = rowSize;
            }
        }

        public Trimsheet(int textureSize, int padding, TrimParams[] rows)
        {
            Size = textureSize;
            Padding = padding;
            RowCount = rows.Length;
            if (!ValidatePadding(textureSize, rows))
            {
                Console.WriteLine("Padding should be the same for all trims!");
            }
        }

        private static bool ValidatePadding(int textureSize, TrimParams[] rows)
        {
            var calcSize = 0;
            for (var i = 0; i < rows.Length; i++)
            {
                calcSize += rows[i].Size;
            }
            return textureSize - calcSize / rows.Length == rows[0].Corner;
        }
    }
}
