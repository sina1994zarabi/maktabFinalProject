using App.Domain.Core.Enums;

namespace FrameWork
{
    public static class StatusEnumExtensions
    {
        private static readonly Dictionary<StatusEnum, string> FarsiEqui = new Dictionary<StatusEnum, string>
        {
            { StatusEnum.AwaitingOfferReveives, "در انتظار دریافت پیشنهاد" },
            { StatusEnum.PendingClientConfirmation, "منتظر تایید مشتری" },
            { StatusEnum.PendingProviderConfirmation, "منتظر تایید کارشناس" },
            { StatusEnum.Completed, "تایید شده" },
            { StatusEnum.Cancelled, "لغو شده" }
    };

        public static string ToFarsiStatus(this StatusEnum status)
        {
            return FarsiEqui.TryGetValue(status, out var farsiEqui) ? farsiEqui : "نامشخص";
        }
    }
}