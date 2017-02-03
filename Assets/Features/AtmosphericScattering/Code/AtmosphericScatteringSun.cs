﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AtmosphericScatteringSun : MonoBehaviour {
	public static AtmosphericScatteringSun instance;

	new public Transform	transform { get; private set; }
	public Light		sunLight { get; private set; }

	void OnEnable() {
		if(instance) {
			Debug.LogErrorFormat("Not setting 'AtmosphericScatteringSun.instance' because '{0}' is already active!", instance.name);
			return;
		}

		this.transform = base.transform;
		this.sunLight = GetComponent<Light>();
		instance = this;

        if (AtmosphericScattering.instance != null)
            AtmosphericScattering.instance.m_ActiveSun = this.sunLight;
	}

	void OnDisable() {
		if(instance == null) {
			Debug.LogErrorFormat("'AtmosphericScatteringSun.instance' is already null when disabling '{0}'!", this.name);
			return;
		}
	
		if(instance != this) {
			Debug.LogErrorFormat("Not UNsetting 'AtmosphericScatteringSun.instance' because it points to someone else '{0}'!", instance.name);
			return;
		}

		if(sunLight)
            sunLight.RemoveAllCommandBuffers();

		instance = null;
	}
}
