using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class WindowEventsManager : MonoBehaviour
{
    public Button lightCord;
    //time event
    bool isCaring = false;
    private GameObject pickedCar;
    private int carNumber;
    [Header("--------------- Cars ----------")]
    public GameObject carBrown;
    public GameObject carOrange;
    public GameObject carBlue;
    public GameObject carRed;
    public GameObject carPolice;
    [SerializeField] AudioSource SoundSorce;
    [SerializeField] AudioSource GlassSoundSorce;
    public AudioClip police;
    public AudioClip glassSound;

    private Vector3 startPosition;

    bool isPeopling = false;
    public GameObject people1;
    //public GameObject people2;
    //public GameObject people3;

    private Vector3 startPosition2;



    bool isBadGuing = false;
    public GameObject badGuy;
    public GameObject badGuyEye;
    public GameObject badGuyFace;
    public GameObject badGuyHand;


    //Situation event
    bool isKiding = false;
    public GameObject kids;
    public GameObject kidsPaper;

    bool isBirding = false;
    public GameObject bird;


    bool phoneRinging = false;
    public GameObject phoneON;

    public GameObject windowKids;
    public GameObject windowBird;
    public GameObject windowDamage_1;
    public GameObject windowDamage_2;
    public GameObject windowDamage_3;
    public GameObject windowDamage_4;
    public GameObject windowDamageFinal;

    public void PlaySound()
    {
        
        SoundSorce.clip = glassSound;
        SoundSorce.Play();
    }

    private void Start()
    {
        lightCord.onClick.AddListener(LightFuncinality);
        StartCoroutine(SceneDelay()); // Uruchamiamy coroutine na pocz¹tku
        StartCoroutine(SceneDelayPeople());
        StartCoroutine(BadGuyEvents());
        startPosition2 = people1.transform.position;
        
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
            SoundSorce.Play();
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

        if (isPeopling)
        {
            // Pozycja docelowa
            Vector3 targetPosition = new Vector3(10f, people1.transform.position.y, people1.transform.position.z);

            // Przesuwanie obiektu w kierunku docelowej pozycji z prêdkoœci¹ moveSpeed
            people1.transform.position = Vector3.MoveTowards(people1.transform.position, targetPosition, 1 * Time.deltaTime);


            // Sprawdzenie, czy pozycja osi¹gnê³a cel
            if (people1.transform.position == targetPosition)
            {
                people1.transform.position = startPosition2;
                people1.SetActive(false);
                isPeopling = false; // Zatrzymanie ruchu po osi¹gniêciu celu
            }
        }
        
    }

    public void Phone()
    {
        phoneON.SetActive(true);
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

    private IEnumerator SceneDelayPeople()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(8, 12));
            isPeopling = true;           
            people1.SetActive(true);            
        }
    }

    private IEnumerator BadGuyEvents()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(8, 15));

            if (GameManager.Instance.badGuyLevel == 0)
            {
                badGuyHand.SetActive(true);
            }
            else if (GameManager.Instance.badGuyLevel == 1)
            {
                badGuy.SetActive(true);
                Debug.Log("badgay zwyk³y");
            }
            else if (GameManager.Instance.badGuyLevel == 2)
            {
                badGuyEye.SetActive(true);
            }
            else if (GameManager.Instance.badGuyLevel == 3)
            {
                badGuyFace.SetActive(true);
            }
            else if (GameManager.Instance.badGuyLevel == 4)
            {
                badGuyFace.SetActive(true);
            }
            else if (GameManager.Instance.badGuyLevel == 5)
            {
                badGuyFace.SetActive(true);
            }
            Debug.Log("badguy dzia³a");

            yield return new WaitForSeconds(7);

            if (GameManager.Instance.isLightON && GameManager.Instance.badGuyLevel == 0)
            {
                GameManager.Instance.badGuyLevel = 1;
                SoundSorce.Play();
            }
            else if (GameManager.Instance.isLightON && GameManager.Instance.badGuyLevel == 1)
            {
                windowDamage_1.SetActive(true);
                badGuy.SetActive(false);
                GameManager.Instance.badGuyLevel = 2;
                SoundSorce.Play();
            }
            else if (GameManager.Instance.isLightON && GameManager.Instance.badGuyLevel == 2)
            {
                windowDamage_2.SetActive(true);
                badGuyEye.SetActive(false);
                GameManager.Instance.badGuyLevel = 3;
                SoundSorce.Play();
            }
            else if (GameManager.Instance.isLightON && GameManager.Instance.badGuyLevel == 3)
            {
                windowDamage_3.SetActive(true);
                badGuyFace.SetActive(false);
                GameManager.Instance.badGuyLevel = 4;
                GlassSoundSorce.Play();
            }
            else if (GameManager.Instance.isLightON && GameManager.Instance.badGuyLevel == 4)
            {
                windowDamage_4.SetActive(true);
                badGuyFace.SetActive(false);
                GameManager.Instance.badGuyLevel = 5;
                GlassSoundSorce.Play();
            }
            else if (GameManager.Instance.isLightON && GameManager.Instance.badGuyLevel == 5)
            {
                windowDamageFinal.SetActive(true);
                badGuyFace.SetActive(false);
                GameManager.Instance.badGuyLevel = 6;
                GlassSoundSorce.Play();
            }
            badGuy.SetActive(false);
            badGuyEye.SetActive(false);
            badGuyFace.SetActive(false);

        }
    }

    public void LightFuncinality()
    {
        if (GameManager.Instance.isLightON == true)
        {
            GameManager.Instance.isLightON = false;
        }
        else
        {
            GameManager.Instance.isLightON = true;
        }
    }


}
