﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube_Type: MonoBehaviour
{

    float target_x;
    float target_z;
    public GameObject Bullet = null;
    public Transform shoot_pos = null;
    public Transform target_pos = null;
    public float attack_speed = 1f;
    public int damage = 20;
    public int speed = 1;
    public GameObject[] cube_type = new GameObject[8];
    public Text Bullet_Count_Text=null;
    public int Bullet_Count;
    public GameObject[] tanlist = new GameObject[20];
    public int Cube_Num;




    void Start()
    {
        Bullet_Count = 0;
        Invoke("Shoot", 1);
    }

    // Update is called once per frame
    void Update()
    {
        setText();
        
    }
    public void Shoot()
    {
        
        if (!GameObject.Find("0"))
        {
            //print("연결이 끊겼습니다. 총알을 쏘지 않습니다");
            Invoke("Shoot", 3);
        }
        else if(GameObject.Find("0") && Bullet_Count != 20)
        {
            //print("총알을 발사합니다.");
            Cube_Num = Random.Range(0, 9);
            Bullet_Count++;
            setText();
            double Angle = 0f;
            switch (Cube_Num)
            {
                case 1:
                    shoot_pos = cube_type[0].GetComponent<Cube_Shoot>().get_shoot_pos();
                    Angle = 180f;
                    StartCoroutine(lockOn_bullet(3, 1, Angle));
                    break;
                case 2:
                    shoot_pos = cube_type[1].GetComponent<Cube_Shoot>().get_shoot_pos();
                    Angle = 0f;
                    StartCoroutine(lockOn_bullet(3, 1, Angle));
                    break;
                case 3:
                    shoot_pos = cube_type[2].GetComponent<Cube_Shoot>().get_shoot_pos();
                    Angle = 90f;
                    StartCoroutine(lockOn_bullet(3, 1, Angle));
                    break;
                case 4:
                    shoot_pos = cube_type[3].GetComponent<Cube_Shoot>().get_shoot_pos();
                    Angle = -90f;
                    StartCoroutine(lockOn_bullet(3, 1, Angle));
                    break;
                case 5:
                    shoot_pos = cube_type[4].GetComponent<Cube_Shoot>().get_shoot_pos();
                    Angle = -135f;
                    StartCoroutine(lockOn_bullet(3, 1, Angle));
                    break;
                case 6:
                    shoot_pos = cube_type[5].GetComponent<Cube_Shoot>().get_shoot_pos();
                    Angle = -45f;
                    StartCoroutine(lockOn_bullet(3, 1, Angle));
                    break;
                case 7:
                    shoot_pos = cube_type[6].GetComponent<Cube_Shoot>().get_shoot_pos();
                    Angle = 135f;
                    StartCoroutine(lockOn_bullet(3, 1, Angle));
                    break;
                case 8:
                    shoot_pos = cube_type[7].GetComponent<Cube_Shoot>().get_shoot_pos();
                    Angle = 45f;
                    StartCoroutine(lockOn_bullet(3, 1, Angle));
                    break;

            }
            Invoke("Shoot", 3);
        }
    }

    IEnumerator lockOn_bullet(int speed, float delay, double angle)
    {
        if (target_pos != null)
        {
            target_x = target_pos.position.x;
            target_z = target_pos.position.z;
        }
        yield return new WaitForSeconds(delay);
        GameObject tan = Instantiate(Bullet, shoot_pos.position, shoot_pos.rotation);
        tan.name = "AR_Bullet" + Bullet_Count.ToString();
        tan.GetComponent<AR_Cube_Bullet>().setDamage(damage);
        tan.GetComponent<AR_Cube_Bullet>().setSpeed(speed);
        tan.transform.rotation = Quaternion.Euler(0, (float)angle, 0);
    }

    public void setText()
    {
        Bullet_Count_Text.text = Bullet_Count.ToString() + " / 20";
    }

    public int get_Bullet_Count()
    {
        return Bullet_Count;
    }
    public GameObject[] get_Bullet()
    {
        return tanlist;
    }

}
