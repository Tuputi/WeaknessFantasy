using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

    public Light worldLight;
    public float FadeDuration = 10000f;
    float currentTime;
    float decreaseAmount;
    Light lightTorch;
    Light lightLarger;
    bool fading = false;

    float changeAmount = -1f;
    float changeAmountL = -0.7f;
    public GameObject playerCharacter;

    public static LightController instance;

    //flicker
   float flickerTime = 0;
    bool flickerOn = false;
    int flickerCounter = 0;

    //scary when player closer to character
    bool flickerStart = false;
    float FadeIntervall = 10f;
    float FadeSpeed = 10f;
    float playerFader = 0f;




    void Start () {
        worldLight = GameObject.Find("WorldLight").GetComponent<Light>();
        lightTorch = playerCharacter.transform.FindChild("light").GetComponent<Light>();
        lightLarger = lightTorch.transform.FindChild("lightLarge").GetComponent<Light>();
        instance = this;
    }
	
	
	void Update () {
        FadeLight(FadeDuration);
        MovingLight();
 

        Flicker(lightTorch, 0.2f, 4);

        if (worldLight.intensity < 0.1f)
        {
            Debug.Log("in here");
            FadePlayerLight();
        }



    }


    void FadeLight(float duration)
    {
        if (!fading)
        {
            currentTime = Time.deltaTime;
            decreaseAmount = 1f / duration;
            fading = true;
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime > duration)
            {
                fading = false;
            }
            else
            {
                worldLight.intensity -= decreaseAmount;
            }
        }
    }

    public void MovingLight()
    {
       
        float curAngle = lightTorch.spotAngle;
        if(curAngle < 60 || curAngle > 75)
        {
            changeAmount *= -1f;
        }
        float random = Random.Range(0.1f, 0.3f);
        lightTorch.spotAngle += changeAmount * random;

        if (flickerStart)
        {
            lightTorch.intensity += changeAmount * random;
        }

        float curAngleLarger = lightLarger.spotAngle;
        if (curAngleLarger < 60 || curAngleLarger > 70)
        {
            changeAmountL *= -1f;
        }
        float randomL = Random.Range(0.1f, 0.3f);
        lightLarger.spotAngle += changeAmountL * randomL;
        //lightLarger.intensity += changeAmountL * randomL * 0.2f;
    }


    public void Flicker(Light light, float frequency, int times)
    {
        if (flickerOn)
        {
            Debug.Log(flickerTime);
            flickerTime += Time.deltaTime;
            if (flickerTime > frequency)
            {
                Debug.Log("in");
                flickerTime = 0;
                light.gameObject.SetActive(!light.gameObject.activeSelf);
                if (flickerCounter > times)
                {
                    flickerOn = false;
                }
                else
                {
                    flickerCounter++;
                }
            }
            
        }
       
    }

    public void CallFlicker()
    {
        flickerStart = true;
    }
    public void CloseFlicker()
    {
        flickerStart = false;
    }


   public void FadePlayerLight()
    {
        playerFader += Time.deltaTime;

        if (playerFader > FadeIntervall)
        {
            float fadeAmount = lightTorch.range / FadeIntervall;
            float fadeamountlarge = lightLarger.range / FadeIntervall;

            lightTorch.range -= fadeAmount;
            lightLarger.range -= fadeamountlarge;
            playerFader = 0;
        }
        if(lightTorch.range <= 3.5f)
        {
            Debug.Log("ENd game");
            CharacterMovement chrMove = GameObject.Find("PlayerCharacter").GetComponentInChildren<CharacterMovement>();
            StartCoroutine(chrMove.PlayEndGameSound());
        }

    }


}
