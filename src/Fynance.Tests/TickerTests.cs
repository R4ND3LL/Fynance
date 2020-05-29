using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fynance.Tests
{
    [TestClass]
    public class TickerTests
    {
        [TestMethod]
        public void Should_download_ticker_data_from_yahoo_finance()
        {
            const string symbol = "ABEV3.SA";

            var ticker = Ticker.Build()
                                .SetSymbol(symbol)
                                .SetPeriod(Period.FiveYears)
                                .SetInterval(Interval.OneDay)
                                .SetEvents(true);

            var result = ticker.Get();

            Assert.IsNotNull(ticker.Result);
            Assert.IsNotNull(result);

            Assert.AreEqual(result.Symbol, symbol);

            Assert.IsNotNull(result.Quotes);
            Assert.IsTrue(result.Quotes.Length > 0);

            Assert.IsNotNull(result.Dividends);
        }

        [TestMethod]
        public void Should_define_a_ticker()
        {
            var result = Ticker.Build("GOOG");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Symbol, "GOOG");
        }

        [TestMethod]
        public void Should_define_a_period()
        {
            var result = Ticker.Build()
                                .SetPeriod(Period.OneYear);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Period, Period.OneYear);
        }

        [TestMethod]
        public void Should_define_an_interval()
        {
            var result = Ticker.Build()
                                .SetInterval(Interval.OneHour);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Interval, Interval.OneHour);
        }

        [TestMethod]
        public void Should_define_an_interval_of_dates()
        {
            var startDate = new DateTime(2020, 1, 1);
            var finishDate = new DateTime(2020, 5, 31);

            var result = Ticker.Build()
                                .SetStartDate(startDate)
                                .SetFinishDate(finishDate);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StartDate, startDate);
            Assert.AreEqual(result.FinishDate, finishDate);
        }

        [TestMethod]
        public void Should_define_an_interval_of_dates_by_set_interval()
        {
            var startDate = new DateTime(2020, 1, 1);
            var finishDate = new DateTime(2020, 5, 31);

            var result = Ticker.Build()
                                .SetInterval(startDate, finishDate);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StartDate, startDate);
            Assert.AreEqual(result.FinishDate, finishDate);
        }

        [TestMethod]
        public void Should_define_a_time_zone()
        {
            var gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");

            var result = Ticker.Build()
                                .SetTimeZone(gmtZone);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TimeZone, gmtZone);
        }

        [TestMethod]
        public void Should_define_local_time_zone()
        {
            var result = Ticker.Build()
                                .SetLocalTimeZone();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TimeZone, TimeZoneInfo.Local);
        }

        [TestMethod]
        public void Should_define_dividends()
        {
            var result = Ticker.Build()
                                .SetDividends(true);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Dividends);
        }

        [TestMethod]
        public void Should_define_splits()
        {
            var result = Ticker.Build()
                                .SetSplits(true);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Splits);
        }

        [TestMethod]
        public void Should_define_events()
        {
            var result = Ticker.Build()
                                .SetEvents(true);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Dividends);
            Assert.IsTrue(result.Splits);
        }
    }
}