using System;
using System.Collections.Generic;
using System.Text;
using Lattice;

namespace NBody
{
	public class Camera
	{
		public double X { get { return Renderer.Camera.X; } }
		public double Y { get { return Renderer.Camera.Y; } }
		public double Z { get { return Renderer.Camera.Z; } }
		
		/// <summary>
		/// The camera field of view. 
		/// </summary>
		private static double CameraFOV = 9e8;

		/// <summary>
		/// The default value for the camera's position on the z-axis. 
		/// </summary>
		private static double CameraZDefault = 1e6;

		/// <summary>
		/// The acceleration constant for camera scrolling. 
		/// </summary>
		private static double CameraZAcceleration = -2e-4;

		/// <summary>
		/// The easing factor for camera scrolling. 
		/// </summary>
		private static double CameraZEasing = 0.94;


		/// <summary>
		/// The camera's position on the z-axis. 
		/// </summary>
		private double _cameraZ = CameraZDefault;

		/// <summary>
		/// The camera's velocity along the z-axis. 
		/// </summary>
		private double _cameraZVelocity = 0;

		/// <summary>
		/// The Renderer instance for drawing 3D graphics. 
		/// </summary>
		public Renderer Renderer { get; private set; }

		public Camera()
		{			 
			Renderer = new Renderer();
			Renderer.Camera.Z = _cameraZ;
			Renderer.FOV = CameraFOV;
		}

		/// <summary>
		/// Update the camera. 
		/// </summary>
		public void Update()
		{			
			_cameraZ += _cameraZVelocity * _cameraZ;
			_cameraZ = Math.Max(1, _cameraZ);
			_cameraZVelocity *= CameraZEasing;
			Renderer.Camera.Z = _cameraZ;
		}
		
		/// <summary>
		/// Moves the camera in association with the given mouse wheel delta. 
		/// </summary>
		/// <param name="delta">The signed number of dents the mouse wheel moved.</param>
		public void Move(int delta)
		{
			_cameraZVelocity += delta * CameraZAcceleration;
		}

		/// <summary>
		/// Resets the camera to its initial position. 
		/// </summary>
		public void Reset()
		{
			_cameraZ = CameraZDefault;
			_cameraZVelocity = 0;
		}
	}
}
