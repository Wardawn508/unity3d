using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//this code is not needed but makes life
//easy to find the script we need in the  menus
[AddComponentMenu("War FPS/Weapon")]
public class Weapon : MonoBehaviour {

   
    public war_MouseLook mouse;

	public WeaponMover weapbeviour;
    [SerializeField]
    public WeaponBaseSystems WeaponLogic;
	public static Weapon weapclass;
    public FPSMakeWeapon Weapondata;
	public WeaponMovements GunPlay;

	public Transform WeaponTrans;
	[SerializeField]
	Transform DropPoint;
	public GameObject Gun;
    private Itemstate currentweap;

    public string t;

    public Itemstate GunObj
	{

		get
		{
			return currentweap;
		}

		set
		{
            if (currentweap != value)
            {
                currentweap = value;
                startchange(value);
            }
		}

	}

	public animbase Anim;

	public float firetime{ get;set; }
	public bool reloading = false;
	public bool debugs = false;

	public bool ReloadingAction
	{

		get
		{
			return reloading;
		}

		set
		{
			
			reload ();
		}

	}


	private WaitForSeconds reLoadStimer;
	public weapontype Weapontype;
	private int shotcount;


	public int shotAction {

		get {
			return shotcount;
		}

		set {
			shotcount = value;
			if (Weapontype == weapontype.brust) {
                InvokeRepeating("shots", 0, .3f);
			}
		}
	}

	public int Ingun;
	public Camera weapCam;
	public WAR_INPUTS input;

	private int currentstate;

    public KeyCode buttion1 = KeyCode.Alpha0;


	// Use this for initialization
	void Start () {
        weapclass = this;
        WeaponLogic = GameState.gamestate.WeaponActions;
		WeaponLogic.OnStart ();
        
        GameState.gamestate.NPCtriggerFixedUpdate += this.WeaponLogic.FixedUpdate;
        weapbeviour.OnStart();
        mouse.Init(this.transform, this.weapCam.transform);
	}
	
	// Update is called once per frame
	void Update () {
        t = System.DateTime.Now.ToString();
		if (Gun == null)
		{
			Debug.LogError (" You have a null gun this can't happen Please setup a starter weapon"); 
			return;
		}else if (Gun != null)
		{
            weapbeviour.OnUpdate();
			//GunPlay.WeapStates ();
		}



        mouse.LookRotation (this.transform, this.weapCam.transform);
        WeaponLogic.OnUpdate();
        UpdateWeapStates();
	}


    public bool changing = false;
    public void startchange(Itemstate gname)
    {
        changing = true;
        StartCoroutine("MyGun", gname);

        /// this plays the animations to put are gun away;
       
    }



    //public AssetBundle asset;

    IEnumerator MyGun(Itemstate assetname)
	{
        //// this plays the animations to put are gun away;
        //Anim.Play("Draw");

        //if (Gun.activeInHierarchy == true)
        //{
        //    yield return null;
        //}
        assetname.Start();
        Weapondata = assetname.Weaponinfo;
        if (Gun != null)
        {
            //Destroy(Gun);
            Gun.SetActive(false);
        }
		yield return new WaitForSeconds (1f);
       
        spawnweapom(assetname);

	}

    void spawnweapom(Itemstate assetname)
    {
        
        
        //GameObject nextweap = (GameObject)Instantiate(assetname.GunObj, DropPoint.transform.localPosition, DropPoint.transform.localRotation);

        GameObject nextweap = assetname.GunObj;
        nextweap.transform.localPosition = DropPoint.localPosition;
        nextweap.transform.SetParent(WeaponTrans,false);
        nextweap.SetActive(true);
        Gun = nextweap;
        firetime = Time.time + Weapondata.fireRate;
        Anim = nextweap.GetComponent<animbase>();
        this.SendMessage("animset", Anim, SendMessageOptions.DontRequireReceiver);
        reLoadStimer = new WaitForSeconds(Weapondata.reloadtime);
        changing = false;
        weapbeviour.OnStart();
        currentstate = 0;
        this.Ingun = assetname.inhan;
        weaptypesetup();
		WeaponLogic.sway.Init (Gun.transform);
    
    }




	private void reload()
	{	
		warLogger.add("reloadcaller");
		
        if (Player_Inventory.playerAmounttypes.ContainsKey(Weapondata.Ammotype) == true)
        {
            Anim.InstantPlay("Reload");
            if (Weapontype != weapontype.shotgun)
            {
                
                StartCoroutine("reloadingchip");
            }
            else if
               (Weapontype == weapontype.shotgun)
            {
                StartCoroutine("reloadingstate");
            }
        }
	}

	IEnumerator reloadingstate()
	{
        reloading = true;
       
        while (Player_Inventory.playerAmounttypes.ContainsKey(Weapondata.Ammotype)
            && Ingun <= Weapondata.MaxInChips)
		{
			Ingun++;
            Player_Inventory.playerAmounttypes[Weapondata.Ammotype]--;
			yield return null;
		}
		yield return reLoadStimer;
		reloading = false;
	}
    IEnumerator reloadingchip()
    {
        reloading = true;

        yield return reLoadStimer;
        Ingun = Player_Inventory.ammogun(Weapondata.Ammotype, Ingun, Weapondata.MaxInChips);
        reloading = false;
    }


	public void shots()
	{
		Ingun--;
		shotcount--;
		if(shotcount ==0 || Ingun <=0   ){CancelInvoke("shots"); }
	}

	private void UpdateWeapStates()
	{


        if (Input.GetKeyDown(buttion1))
        {
            currentstate = (currentstate + 1) % Weapondata.weapSchanger.Length;
            weaptypesetup();
        }

 

        }

    private void weaptypesetup() 
    {
        if (Weapondata == null) { return; }

        input.auto = Weapondata.weapSchanger[currentstate].isauto;
        this.Weapontype = Weapondata.weapSchanger[currentstate].weapSchanger;
    
    }
}
