using UnityEngine;

[RequireComponent(typeof(Timer))]
public class SceneController : MonoBehaviour
{
    [SerializeField] private Targets _targets;
    [SerializeField] private GameObject target;
    private Timer _timer;
    
    private void Awake()
    {
        _timer = GetComponent<Timer>();
        _timer.Init(TimerAction);
    }

    private int count = 0;
    
    void TimerAction()
    {

        if (count < _targets.Count)
        {
            Instantiate(target, _targets._transforms[count].transform.position, Quaternion.identity);
            count++;
        }
        else
        {
            _timer.IsStop = true;
        }
        
    }
}
