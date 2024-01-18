namespace Sailfish.Analysis.SailDiff.Statistics.StatsCore;

public interface IRandomNumberGenerator<T>
{
    T[] Generate(int samples);

    T[] Generate(int samples, T[] result);

    T Generate();
}