using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]
public class AudioGuidePage : Page
{
    private AudioSource _audioSource;
    private bool _isPlaying;
    private Slider _audioSlider;

    private void Update()
    {
        if (_audioSource.clip != null)
        {
            // Update the slider value to match the playback progress
            _audioSlider.value = _audioSource.time / _audioSource.clip.length * _audioSlider.highValue;
        }
    }

    public void Activate(Location location)
    {
        base.Activate();   
        _audioSource = GetComponent<AudioSource>();
        _root.Q<Button>("playpause").clicked += PlayPause;
        _root.Q<Button>("cancel").clicked += Cancel;

        _root.Q<Label>("title").text = location.name;
        _root.Q<Label>("other").text = location.description;
        
        _audioSlider = _root.Q<Slider>();
        _audioSlider.RegisterValueChangedCallback(OnSliderValueChanged);
        
        AudioClip clip = location.audioGuide;
        _audioSource.clip = clip;
        _audioSource.Play();
        _isPlaying = true;

        // Set the slider range based on the audio clip duration
        _audioSlider.lowValue = 0;
        _audioSlider.highValue = clip.length;
    }

    private void PlayPause()
    {
        if (_isPlaying)
            _audioSource.Pause();
        else
            _audioSource.Play();

        _isPlaying = !_isPlaying;
    }

    private void Cancel()
    {
        this.Deactivate();
    }

    private void OnSliderValueChanged(ChangeEvent<float> evt)
    {
        if (_audioSource.clip != null)
        {
            _audioSource.time = evt.newValue;
        }
    }
}