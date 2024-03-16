using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Alarm alarm;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I am in");

        if (other.TryGetComponent<Thief>(out _))
        {
            alarm.ActivateAlarm();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("I am Exit");

        if (other.TryGetComponent<Thief>(out _))
        {
            alarm.DeactivateAlarm();
        }
    }
}
