using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTriggerScript : MonoBehaviour
{

    public float damage = 7f;
    public float range = 200f;
    public float appliedForce = 60f;
    public Camera cam;

    //here we create firerate of gun
    public float fireRate = 10f;
    private float nextBullet = 0f;

    //for reloading 
    public int fullAmmo = 10;
    private bool isReloading = false;
    private int presentAmmo;

    //muzzel flash
    public ParticleSystem particles;
    private Animator animator;


  private void Start() {
    animator = GetComponent<Animator>();
    //this means when ever game starts current ammo will be the max ammo
    presentAmmo = fullAmmo;  
  }

  void Update(){
      //only starts condition, if isReloading is true
      if(isReloading){
        return;
      }
      if(presentAmmo <= 0){
        // Inorder to start IEnumerator we have to use StartCoroutine()
        StartCoroutine(Reload());
        return;
      }

      if(Input.GetButton("Fire1") && Time.time >= nextBullet){
        //here after each fire rate there gonna be next fire rate.
        nextBullet = Time.time + 1f/fireRate; 
        Shoot();
      }
    }

  IEnumerator Reload(){
      Debug.Log("Reloading");
      isReloading = true;
      animator.SetBool("Reload", true);
      //when reload current ammo will the max ammo
      presentAmmo = fullAmmo;
      //it will take some time to reload
      yield return new WaitForSeconds(1f);
      isReloading = false;
      animator.SetBool("Reload", false);
    }

  void Shoot(){
        //run muzzel flash vfx in sync with bullet fire
        particles.Play();
        presentAmmo--;
      //here we are create a fire rate that means a gun can auto fire bullets after long pressing left click on mouse.
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
            //check if impacted object had rigidbody
            if(hit.rigidbody != null){
                // minus hit.normal because if object hit is applied, the object which got hit will move opposite way.
                hit.rigidbody.AddForce(-hit.normal * appliedForce);
            }
            //here we are calling enemy script
            EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();
            //here it will take hit component and use this value to update GetDamage method.
            if(enemy != null){
              enemy.GetDamage(damage);
            }
        }
    }
}
