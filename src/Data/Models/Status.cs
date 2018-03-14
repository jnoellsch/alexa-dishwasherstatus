﻿namespace Alexa.Data.Models
{
    using System;

    /// <summary>
    /// The common signature for dishwasher status.
    /// </summary>
    public abstract class Status
    {
        public abstract int Code { get; }

        public abstract string Text { get; }

        public static Status FromCode(int code)
        {
            switch (code)
            {
                case 1:
                    return new CleanStatus();
                case -1:
                    return new DirtyStatus();
                default:
                    return new UnknownStatus();
            }
        }

        public static Status FromCode(string code) => FromCode(Convert.ToInt32(code));
    }
}