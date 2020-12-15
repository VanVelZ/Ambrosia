CREATE PROCEDURE [dbo].[SPCalcCaloriesBurned]
	@StartTime datetime,
	@EndTime datetime,
	@CaloriesPerMinute decimal
AS
	SELECT DateDiff(minute, @StartTime, @EndTime) * @CaloriesPerMinute
RETURN 0
