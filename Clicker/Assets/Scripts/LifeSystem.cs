
using UnityEngine;

public class LifeSystem : Action
{
    [Header("Life counter")] [SerializeField]
    private int life = 1;

    [Header("Actions on hit")] [SerializeField]
    private Action[] actionsOnHit;

    [Header("Actions on death")] [SerializeField]
    private Action[] actionsOnDeath;

    private Color _color;

    private void Start()
    {
        _color = GetComponent<Renderer>().material.color;
        GameObject score = GameObject.Find("Score");
        actionsOnDeath = new Action[]
        {
            GetComponent<DestroyAction>(),
            score.GetComponent<ScoreController>()
        };
        GameObject hit = GameObject.Find("HitImage");
        actionsOnHit = new Action[]
        {
            hit.GetComponent<HitAction>()
        };
    }

    public override bool ExecuteAction(GameObject otherObject)
    {
        life--;
        _color = new Color(_color.r + 10, _color.g, _color.b);

        foreach (var variable in actionsOnHit)
        {
            variable.ExecuteAction(gameObject);
        }

        if (life < 1)
        {
            foreach (var variable in actionsOnDeath)
            {
                variable.ExecuteAction(null);
            }

            Destroy(gameObject);
        }

        return true;
    }
}