// <copyright file="Batch.cs" company="BroMandarin">
// Copyright (c) BroMandarin. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MandarinBatcher
{
	/// <summary>
	/// Base abstract Batch class.
	/// </summary>
	public class Batch
	{
		private byte[] data = Array.Empty<byte>();
		private uint[] indices = Array.Empty<uint>();

		/// <summary>
		/// Initializes a new instance of the <see cref="Batch"/> class.
		/// </summary>
		/// <param name="attribPointers">List of <see cref="AttribPointer"/> that describes vertex data layout.</param>
		/// <param name="meshSize">Number of vertices.</param>
		/// <param name="program">Shader program handle.</param>
		/// <param name="textures">Texture handles.</param>
		public Batch(List<AttribPointer> attribPointers, int meshSize, int program, params int[] textures)
		{
			AttribPointers = attribPointers;
			ProgramHandle = program;
			TextureHandles = textures;
			MeshSize = meshSize;
			GLStates = new List<IGLState>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Batch"/> class.
		/// </summary>
		/// <param name="glStates">Optional array of <see cref="IGLState"/> for additional sates batching.</param>
		/// <param name="attribPointers">List of <see cref="AttribPointer"/> that describes vertex data layout.</param>
		/// <param name="meshSize">Number of vertices.</param>
		/// <param name="program">Shader program handle.</param>
		/// <param name="textures">Texture handles.</param>
		public Batch(IGLState[] glStates, List<AttribPointer> attribPointers, int meshSize, int program, params int[] textures)
		{
			AttribPointers = attribPointers;
			ProgramHandle = program;
			TextureHandles = textures;
			MeshSize = meshSize;
			GLStates = glStates.ToList();
		}

		/// <summary>
		/// Gets VertexArrayObject of <see cref="StaticBatch"/>.
		/// </summary>
		public int VertexArrayObject { get; private set; }

		/// <summary>
		/// Gets VertexBufferObject of <see cref="StaticBatch"/>.
		/// </summary>
		public int VertexBufferObject { get; private set; }

		/// <summary>
		/// Gets ElementBufferObject of <see cref="StaticBatch"/>.
		/// </summary>
		public int ElementBufferObject { get; private set; }

		/// <summary>
		/// Gets Shader handle used by <see cref="StaticBatch"/>.
		/// </summary>
		public int ProgramHandle { get; }

		/// <summary>
		/// Gets Texture handles used by <see cref="StaticBatch"/>.
		/// </summary>
		public int[] TextureHandles { get; }

		/// <summary>
		/// Gets or sets PrimitiveType used by Batch.
		/// </summary>
		public PrimitiveType PrimitiveType { get; set; } = PrimitiveType.Triangles;

		/// <summary>
		/// Gets number of vertices in Batch.
		/// </summary>
		public int Count { get; private set; }

		/// <summary>
		/// Gets number of vertices per mesh to be batched.
		/// </summary>
		public int MeshSize { get; }

		/// <summary>
		/// Gets a list of AttribPointers used by Batch.
		/// </summary>
		public List<AttribPointer> AttribPointers { get; }

		/// <summary>
		/// Gets a list of custom IGLStates to be batched.
		/// </summary>
		public List<IGLState> GLStates { get; }

		/// <summary>
		/// Adds a mesh to Batch.
		/// </summary>
		/// <param name="data">Byte array of vertex data stored in ababab layout.</param>
		/// <param name="indices">Vertex indices for EBO.</param>
		public void AddMesh(byte[] data, uint[] indices)
		{
			int length = this.data.Length;
			Array.Resize(ref this.data, this.data.Length + data.Length);
			Array.Copy(data, 0, this.data, length, data.Length);

			if (this.indices.Length > 0)
			{
				for (int i = 0; i < indices.Length; i++)
				{
					indices[i] += (uint)(4 * (Count / 6));
				}
			}

			int indicesLength = this.indices.Length;
			Array.Resize(ref this.indices, this.indices.Length + indices.Length);
			Array.Copy(indices, 0, this.indices, indicesLength, indices.Length);

			Count += MeshSize;
		}

		/// <summary>
		/// Create batch buffers using vertex data provided.
		/// </summary>
		public void Initialize()
		{
			VertexArrayObject = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayObject);

			VertexBufferObject = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
			GL.BufferData(BufferTarget.ArrayBuffer, data.Length, data, BufferUsageHint.DynamicDraw);

			ElementBufferObject = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
			GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.DynamicDraw);

			foreach (AttribPointer attribPointer in AttribPointers)
			{
				GL.VertexAttribPointer(attribPointer.Index, attribPointer.Size, attribPointer.VertexAttribPointerType, attribPointer.Normalized, attribPointer.Stride, attribPointer.Offset);
				GL.EnableVertexAttribArray(attribPointer.Index);
			}
		}
	}
}
