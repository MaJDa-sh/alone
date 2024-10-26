using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class WindowEventsManager : MonoBehaviour
{
    
    //time event
    bool isCaring = false;
    private GameObject pickedCar;
    private int carNumber;
    public GameObject carBrown;
    public GameObject carOrange;
    public GameObject carBlue;
    public GameObject carRed;
    public GameObject carPolice;

    private Vector3 startPosition;

    bool isPeopling = false;
    public GameObject people;

    bool isBadGuing = false;
    public GameObject badguy;


    //Situation event
    bool isKiding = false;
    public GameObject kids;

    bool isBirding = false;
    public GameObject bird;

    private void Start()
    {
        StartCoroutine(SceneDelay()); // Uruchamiamy coroutine na pocz¹tku
    }


    public void CarMoving()
    {
        carNumber = Random.Range(1, 6);
        if (carNumber == 1)
        {
            carBrown.SetActive(true);
            pickedCar = carBrown;
        }
        else if (carNumber == 2)
        {
            carOrange.SetActive(true);
            pickedCar = carOrange;
        }
        else if (carNumber == 3)
        {
            carBlue.SetActive(true);
            pickedCar = carBlue;
        }
        else if (carNumber == 4)
        {
            carRed.SetActive(true);
            pickedCar = carRed;
        }
        else if (carNumber == 5)
        {
            carPolice.SetActive(true);
            pickedCar = carPolice;
        }
        if (pickedCar != null)
        {
            startPosition = pickedCar.transform.position; // Zapisanie pozycji startowej
            pickedCar.SetActive(true);
        }


    }

    private void Update()
    {
        
        if (isCaring && pickedCar != null)
        {
            Debug.Log("Samochód rusza...");

            // Pozycja docelowa
            Vector3 targetPosition = new Vector3(-10f, pickedCar.transform.position.y, pickedCar.transform.position.z);

            // Przesuwanie obiektu w kierunku docelowej pozycji z prêdkoœci¹ moveSpeed
            pickedCar.transform.position = Vector3.MoveTowards(pickedCar.transform.position, targetPosition, 6 * Time.deltaTime);
            

            // Sprawdzenie, czy pozycja osi¹gnê³a cel
            if (pickedCar.transform.position == targetPosition)
            {
                pickedCar.transform.position = startPosition;
                pickedCar.SetActive(false);
                isCaring = false; // Zatrzymanie ruchu po osi¹gniêciu celu
            }
        }
        
    }


    public void People()
    {

    }
    public void BadGuy()
    {

    }
    public void Kids()
    {

    }
    public void Bird()
    {

    }
    private IEnumerator SceneDelay()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 12)); // Ustalanie czasu miêdzy przejazdami
            isCaring = true;
            CarMoving(); // Losowanie samochodu i uruchomienie ruchu
        }
    }

}
