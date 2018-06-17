using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance { get { return GetInstance(); } }

	#region Singleton
	private static AudioManager instance;

	private static AudioManager GetInstance()
	{
		if (instance == null)
		{
			instance = FindObjectOfType<AudioManager>();
		}
		return instance;
	}
	#endregion

	public List<AudioClip> clips = new List<AudioClip>();
	public bool[] soundsPlaying;
	public delegate void DonePlaying();
	private AudioSource source;

	void Awake()
	{
		source = GetComponent<AudioSource>();
		soundsPlaying = new bool[clips.Count];
	}

	public void PlayAudioIfNotPlaying(int audioID)
	{
		PlayAudioIfNotPlaying(audioID, null);
	}

	public void PlayAudioIfNotPlaying(int audioID, DonePlaying returnDelegate)
	{
		if (!soundsPlaying[audioID])
		{
			soundsPlaying[audioID] = true;
			StartCoroutine(SoundDonePlaying(returnDelegate, audioID, clips[audioID].length));
			source.PlayOneShot(clips[audioID], 1);
		}
	}

	public void PlayAudio(int audioID)
	{
		PlayAudio(audioID, null);
	}

	public void PlayAudio(int audioID, DonePlaying returnDelegate)
	{
		StartCoroutine(SoundDonePlaying(returnDelegate, audioID, clips[audioID].length));
		soundsPlaying[audioID] = true;
		source.PlayOneShot(clips[audioID], 1);
	}

	public void StartAfterDelay(int audioID, float delay, DonePlaying returnDelegate)
	{
		source.clip = clips[audioID];
		source.PlayDelayed(delay);
	}

	public void PlayAtPosition(int audioID, Vector3 position)
	{
		PlayAtPosition(audioID, null, position);
	}

	public void PlayAtPosition(int audioID, DonePlaying returnDelegate, Vector3 position)
	{
		StartCoroutine(SoundDonePlaying(returnDelegate, audioID, clips[audioID].length));
		soundsPlaying[audioID] = true;

		AudioSource.PlayClipAtPoint(clips[audioID], position);
	}

	public void StopAudio(int audioId)
	{
		if (soundsPlaying[audioId])
		{
			soundsPlaying[audioId] = false;
			source.Stop();
		}
	}

	public IEnumerator SoundDonePlaying(DonePlaying returnDelegate, int audioID, float waitTime)
	{
		yield return new WaitForSeconds(waitTime);

		soundsPlaying[audioID] = false;

		if (returnDelegate != null) returnDelegate();

		yield return null;
	}
}