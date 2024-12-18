using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento
{
        private float velocidadMovimiento;
        private float velocidadRotacion;
        private Transform transform;

        public Movimiento(Transform transform, float velocidadMovimiento, float velocidadRotacion)
        {
            this.transform = transform;
            this.velocidadMovimiento = velocidadMovimiento;
            this.velocidadRotacion = velocidadRotacion;
        }

        public void Mover(float x, float y)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }
}
