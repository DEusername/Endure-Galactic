using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastMovement : MonoBehaviour
{
    public SpriteRenderer playerSpriteRenderer;
    public SpriteRenderer turret1SpriteRenderer;
    public SpriteRenderer turret2SpriteRenderer;
    public GameObject engine;
    public playerMovement playerMovementSystem;
    public createBullet bullSys1;
    public createBullet bullSys2;
    public createBullet bullSys3;
    public createMissile missSys1;
    public createMissile missSys2;

    public Color fastModeColor;
    private Color originalColor;
    private bool inFastMode = false;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = playerSpriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1) && Time.timeScale != 0f && !inFastMode)
        {
            EnterFastMode();
        }
        else if( (!Input.GetMouseButton(1) || Time.timeScale == 0f) && inFastMode)
        {
            ExitFastMode();
        }
    }

    private void EnterFastMode()
    {
        inFastMode = true;
        engine.SetActive(false);
        playerSpriteRenderer.color = fastModeColor;
        turret1SpriteRenderer.color = fastModeColor;
        turret2SpriteRenderer.color = fastModeColor;
        bullSys1.stopShoot();
        bullSys2.stopShoot();
        bullSys3.stopShoot();
        missSys1.stopShoot();
        missSys2.stopShoot();
        playerMovementSystem.FastModeSetTrue();
    }

    private void ExitFastMode()
    {
        inFastMode = false;
        engine.SetActive(true);
        playerSpriteRenderer.color = originalColor;
        turret1SpriteRenderer.color = originalColor;
        turret2SpriteRenderer.color = originalColor;
        bullSys1.startShoot();
        bullSys2.startShoot();
        bullSys3.startShoot();
        missSys1.startShoot();
        missSys2.startShoot();
        playerMovementSystem.FastModeSetFalse();
    }
}
