using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyVariable : MonoBehaviour
{
    [SerializeField] float _stress = 0.0f; //��Ʈ����
    public float Stress { get { return _stress; } }
    [SerializeField] float _stamina = 100f; //ü��
    public float Stamina { get { return _stamina; } }
    [SerializeField] float _fullness = 100f; //��θ�
    public float Fullness { get { return _fullness; } }
    [SerializeField] float _cleanliness = 100f; //û�ᵵ
    public float Cleanliness { get { return _cleanliness; } }
    [SerializeField] float _toilet = 0.0f;
    public float Toilet { get { return _toilet; } }

    [SerializeField] int _chance = 3; //��ȸ(���)
    public int Chance { get { return _chance; } }

    [SerializeField] float _fullnessDecreaseRate = 1.0f;
    [SerializeField] float _cleanlinessDecreaseRate = 1.0f;
    [SerializeField] float _staminaDecreaseRate = 1.0f;

    float _stressIncreaseRateByStamina = 0.0f;
    float _stressIncreaseRateByFullness = 0.0f;
    float _stressIncreaseRateByCleanliness = 0.0f;

    void UpdateFullness()
    {
        _fullness -= _fullnessDecreaseRate * Time.deltaTime;
        _fullness = Mathf.Clamp(_fullness, 0f, 100f);
    }

    void UpdateCleanliness()
    {
        _cleanliness -= _cleanlinessDecreaseRate * Time.deltaTime;
        _cleanliness = Mathf.Clamp(_cleanliness, 0f, 100f);
    }

    void UpdateStamina()
    {
        _stamina -= _staminaDecreaseRate * Time.deltaTime;
        _stamina = Mathf.Clamp(_stamina, 0f, 100f);
    }

    void UpdateToliet()
    {
        _toilet += Time.deltaTime;
        _toilet = Mathf.Clamp(_toilet, 0f, 100f);
    }

    void UpdateStress()
    {
        if (_fullness <= 0f)
        {
            _stressIncreaseRateByFullness = 6.0f;
        }
        else if (_fullness <= 10f)
        {
            _stressIncreaseRateByFullness = 3.0f;
        }
        else if (_fullness <= 20f)
        {
            _stressIncreaseRateByFullness = 2.0f;
        }
        else if (_fullness <= 30f)
        {
            _stressIncreaseRateByFullness = 1.0f;
        }
        else
        {
            _stressIncreaseRateByFullness = 0.0f;
        }

        if (_cleanliness <= 0f)
        {
            _stressIncreaseRateByCleanliness = 4.0f;
        }
        else if (_cleanliness <= 10f)
        {
            _stressIncreaseRateByCleanliness = 2.0f;
        }
        else if (_cleanliness <= 20f)
        {
            _stressIncreaseRateByCleanliness = 1.0f;
        }
        else
        {
            _stressIncreaseRateByCleanliness = 0.0f;
        }

        if (_stamina <= 0f)
        {
            _stressIncreaseRateByStamina = 6.0f;
        }
        else if (_stamina <= 10f)
        {
            _stressIncreaseRateByStamina = 3.0f;
        }
        else if (_stamina <= 20f)
        {
            _stressIncreaseRateByStamina = 2.0f;
        }
        else if (_stamina <= 30f)
        {
            _stressIncreaseRateByStamina = 1.0f;
        }
        else
        {
            _stressIncreaseRateByStamina = 0.0f;
        }

        _stress += (_stressIncreaseRateByFullness + _stressIncreaseRateByCleanliness + _stressIncreaseRateByStamina) * Time.deltaTime;
        if (_stress >= 100.0f)
        {
            DecreaseChance();
        }
        _stress = Mathf.Clamp(_stress, 0.0f, 100.0f);
    }

    private void Update()
    {
        UpdateFullness();
        UpdateCleanliness();
        UpdateStamina();
        UpdateStress();
        UpdateToliet();
    }

    public void DecreaseChance()
    {
        _chance--;
        if (_chance == 0)
        {
            Debug.Log("Game Over");
        }
        else
        {
            _stress = 50.0f;
            Debug.Log("��ȸ ����");
        }
    }

    public void Eat()
    {
        _stamina += 25.0f;
        Mathf.Clamp(_stamina, 0.0f, 100.0f);
        _fullness += 25.0f;
        Mathf.Clamp(_fullness, 0.0f, 100.0f);
    }

    public void Wash()
    {
        _cleanliness += 50.0f;
        Mathf.Clamp(_cleanliness, 0.0f, 100.0f);
    }

    public void Sleep()
    {
        _stamina += 50.0f;
        Mathf.Clamp(_stamina, 0.0f, 100.0f);
    }

}
