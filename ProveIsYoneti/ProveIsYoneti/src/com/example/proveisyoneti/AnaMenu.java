package com.example.proveisyoneti;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.RelativeLayout;

public class AnaMenu extends Activity{
	RelativeLayout layyok,layyemek;
	ImageButton yokbt,yembt;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.anamenu);
		layyok=(RelativeLayout)findViewById(R.id.layyok);
		layyemek=(RelativeLayout)findViewById(R.id.layyemekk);
		yokbt=(ImageButton)findViewById(R.id.imageButton1);
		yembt=(ImageButton)findViewById(R.id.imageButton2);
		yokbt.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				layyok.setVisibility(View.VISIBLE);
				layyemek.setVisibility(View.INVISIBLE);
				
			}
		});
		yembt.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				layyok.setVisibility(View.INVISIBLE);
				layyemek.setVisibility(View.VISIBLE);
				
			}
		});
	}

	
}
