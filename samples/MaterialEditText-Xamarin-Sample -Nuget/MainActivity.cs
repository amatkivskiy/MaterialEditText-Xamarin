namespace MaterialEditTextXamarinSample
{
  using Android.App;
  using Android.OS;
  using Android.Support.V7.App;
  using Android.Views;
  using Android.Widget;
  using Rengwuxian.MaterialEditText;
  using Rengwuxian.MaterialEditText.Validations;

  [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher", Theme = "@style/AppTheme", WindowSoftInputMode = SoftInput.StateUnchanged)]
  public class MainActivity : AppCompatActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      this.SetContentView(Resource.Layout.activity_main);

      this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
      this.SupportActionBar.SetDisplayShowTitleEnabled(false);

      this.InitEnableBt();
      this.InitSingleLineEllipsisEt();
      this.InitSetErrorEt();
      this.InitValidationEt();
    }

    private void InitEnableBt()
    {
      var basicEt = this.FindViewById<EditText>(Resource.Id.basicEt);
      var enableBt = this.FindViewById<Button>(Resource.Id.enableBt);
      enableBt.Click += (sender, e) =>
      {
        basicEt.Enabled = !basicEt.Enabled;
        enableBt.Text = basicEt.Enabled ? "DISABLE" : "ENABLE";
      };
    }

    private void InitSingleLineEllipsisEt()
    {
      var singleLineEllipsisEt = this.FindViewById<EditText>(Resource.Id.singleLineEllipsisEt);
      singleLineEllipsisEt.SetSelection(singleLineEllipsisEt.Text.Length);
    }

    private void InitSetErrorEt()
    {
      var bottomTextEt = this.FindViewById<EditText>(Resource.Id.bottomTextEt);
      var setErrorBt = this.FindViewById<Button>(Resource.Id.setErrorBt);
      setErrorBt.Click += (sender, e) => bottomTextEt.Error = "1-line Error!";

      var setError2Bt = this.FindViewById<Button>(Resource.Id.setError2Bt);
      setError2Bt.Click += (sender, e) => bottomTextEt.Error = "2-line\nError!";

      var setError3Bt = this.FindViewById<Button>(Resource.Id.setError3Bt);
      setError3Bt.Click += (sender, e) =>
      {
        bottomTextEt.Error = "So Many Errors! So Many Errors! So Many Errors! So Many Errors! So Many Errors! So Many Errors! So Many Errors! So Many Errors!";
      };
    }

    private void InitValidationEt()
    {
      var validationEt = this.FindViewById<MaterialEditText>(Resource.Id.validationEt);
      validationEt.AddValidator(new RegexpValidator("Only Integer Valid!", "\\d+"));
      var validateBt = this.FindViewById<Button>(Resource.Id.validateBt);
      validateBt.Click += (sender, e) => validationEt.Validate();
    }

    public override bool OnCreateOptionsMenu(IMenu menu)
    {
      // Inflate the menu; this adds items to the action bar if it is present.
      this.MenuInflater.Inflate(Resource.Menu.menu_main, menu);
      return true;
    }
    //
    public override bool OnOptionsItemSelected(IMenuItem item)
    {
      // Handle action bar item clicks here. The action bar will
      // automatically handle clicks on the Home/Up button, so long
      // as you specify a parent activity in AndroidManifest.xml.
      var id = item.ItemId;
    
      //noinspection SimplifiableIfStatement
      if(id == Resource.Id.action_settings)
      {
        return true;
      }
    
      return base.OnOptionsItemSelected(item);
    }
  }
}


