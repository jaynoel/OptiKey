﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using JuliusSweetland.OptiKey.Properties;

namespace JuliusSweetland.OptiKey.UI.ValueConverters
{
    public class CalculateScratchpadWidth : IMultiValueConverter
    {
        public int DefaultGridLength { get; set; }
        
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 3)
            {
                return new GridLength(DefaultGridLength, GridUnitType.Star);
            }

            int scratchpadWidthInKeys = (int) values[0];
            bool attentionKeyEnabled = (bool)values[1];
            bool ckKeyEnabled = (bool)values[2];

            if (scratchpadWidthInKeys <= 0)
            {
                scratchpadWidthInKeys = DefaultGridLength;
            }

            if (attentionKeyEnabled)
            {
                --scratchpadWidthInKeys;
            }

            if (ckKeyEnabled)
            {
                --scratchpadWidthInKeys;
            }

            return new GridLength(scratchpadWidthInKeys, GridUnitType.Star);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
