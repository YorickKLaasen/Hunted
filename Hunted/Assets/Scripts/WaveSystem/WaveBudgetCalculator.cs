using UnityEngine;
public class WaveBudgetCalculator
{
    private readonly float difficultyMultiplier;
    private int currentBudget;

    public WaveBudgetCalculator(int startBudget, float difficultyMultiplier)
    {
        this.difficultyMultiplier = difficultyMultiplier;
        this.currentBudget = startBudget;
    }

    public int GetCurrentBudget() => currentBudget;

    public void AdvanceToNextWave()
    {
        currentBudget = Mathf.RoundToInt(currentBudget * difficultyMultiplier);
    }
}