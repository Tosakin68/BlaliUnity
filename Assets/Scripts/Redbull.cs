using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redbull : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Collider2D _collider;
    AudioSource _audioSource;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
            _audioSource.Play();
            Destroy(gameObject, _audioSource.clip.length);

        }
    }
}
