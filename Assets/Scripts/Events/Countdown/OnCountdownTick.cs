using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCountdownTick : IEvent
{
    public int Count { get; }
    public int FontSize { get; }
    public int FinalFontSize { get; }

    public OnCountdownTick(int count, int fontSize, int finalFontSize)
    {
        Count = count;
        FontSize = fontSize;
        FinalFontSize = finalFontSize;
    }
}
