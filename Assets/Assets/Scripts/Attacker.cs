using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public string cardName;
    public string type;
    public int cost;
    public float hp;
    public float cardDamage;
    public bool activeCard;
    public int team;
    float extraBuffDmg;
    float extraTypeDmg;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float CalculateHitDamage(string typeOpponent)
    {
        float buffedDmg = cardDamage + extraTypeDmg + extraBuffDmg;

        float finalDmg = buffedDmg;
        return finalDmg;
    }
    
    public bool TakeDamageAndCheckDeath(int damageTaken)
    {
        hp -= damageTaken;
        bool isDead = false;
        if (hp < 0)
        {
            hp = 0;
            isDead = true;
        }

        return isDead;
    }
    //Percentage = True é Porcentagem, False é Bruto(2 de buff direto)
    //qtt = Quanto de Buff(ex: 15% ou 2 de dano extra)
    //affectType = Buff ou Debuff
    //statusToAffect = Vida ou Dano
    public void ReceiveBuff(bool Percentage, float qtt, string affectType, string statusToAffect)
    {
        float PosOrNeg = 1.0f;
        if (affectType == "Debuff") PosOrNeg = -1.0f;
        if(statusToAffect == "Damage")
        {
            if (Percentage)
            {
                float currDmg = cardDamage + extraTypeDmg;
                float percentExtra = (currDmg * 100) / qtt;
                extraBuffDmg += percentExtra * PosOrNeg;
            }
            else
            {
                extraBuffDmg += qtt * PosOrNeg;
            }
        }
        else if(statusToAffect == "Health")
        {
            if (Percentage)
            {
                float percentExtra = (hp * 100) / qtt;
                hp += percentExtra * PosOrNeg;
            }
            else
            {
                hp += qtt * PosOrNeg;
            }
        }
    }
    void Die() {
        Destroy(gameObject);
    }
    void CompareType(string typeOpponent)
    {
        extraTypeDmg = 0;
        if(type == "Fe")
        {
            if(typeOpponent == "Crime")
            {
                extraTypeDmg = 1;
            }
            else if(typeOpponent == "Gambiarra")
            {
                extraTypeDmg = -1;
            }
        }
        else if (type == "Crime")
        {
            if (typeOpponent == "Povao")
            {
                extraTypeDmg = 1;
            }
            else if (typeOpponent == "Fe")
            {
                extraTypeDmg = -1;
            }
        }
        else if (type == "Povao")
        {
            if (typeOpponent == "Gambiarra")
            {
                extraTypeDmg = 1;
            }
            else if (typeOpponent == "Crime")
            {
                extraTypeDmg = -1;
            }
        }
        else if (type == "Gambiarra")
        {
            if (typeOpponent == "Fe")
            {
                extraTypeDmg = 1;
            }
            else if (typeOpponent == "Povao")
            {
                extraTypeDmg = -1;
            }
        }
    } 
}
