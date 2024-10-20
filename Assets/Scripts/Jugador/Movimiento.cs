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

        public void Mover(float inputHorizontal, float inputVertical)
        {
            transform.Rotate(0, inputHorizontal * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, inputVertical * Time.deltaTime * velocidadMovimiento);
        }
}
