public class ResourceGenerationRuntime
{
    public ResourceGenerationRule rule;
    public float timer;

    public ResourceGenerationRuntime(ResourceGenerationRule rule)
    {
        this.rule = rule;
        this.timer = rule.generationInterval;
    }

    public bool Tick(float deltaTime)
    {
        timer -= deltaTime;
        if (timer <= 0f)
        {
            timer += rule.generationInterval;
            return true; // Time to generate
        }
        return false;
    }
}

