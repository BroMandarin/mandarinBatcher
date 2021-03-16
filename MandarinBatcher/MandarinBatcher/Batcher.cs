// <copyright file="Batcher.cs" company="BroMandarin">
// Copyright (c) BroMandarin. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;

namespace MandarinBatcher
{
	/// <summary>
	/// Stores and manages a list of Batches.
	/// </summary>
	public class Batcher
	{
		/// <summary>
		/// Gets batches.
		/// </summary>
		public List<Batch> Batches { get; } = new List<Batch>();

		/// <summary>
		/// Adds <see cref="Mesh"/> to new or existing <see cref="StaticBatch"/>.
		/// </summary>
		/// <param name="glStates">Array of <see cref="IGLState"/> for additional states batching.</param>
		/// <param name="data">Vertex data.</param>
		/// <param name="indices">Vertex indices.</param>
		/// <param name="attribPointers">List of <see cref="AttribPointer"/> that represents vertex data layout.</param>
		/// <param name="count">Count of vertices.</param>
		/// <param name="program">Shader handle used by mesh.</param>
		/// <param name="textures">Texture handle used by mesh.</param>
		public void AddMesh(IGLState[] glStates, byte[] data, uint[] indices, List<AttribPointer> attribPointers, int count, int program, params int[] textures) // params IGLState[]
		{
			bool createNew = true;

			foreach (Batch batch in Batches)
			{
				if (batch.MeshSize == count && batch.AttribPointers.SequenceEqual(attribPointers) && batch.GLStates.SequenceEqual(glStates) && batch.ProgramHandle == program && batch.TextureHandles.SequenceEqual(textures))
				{
					createNew = false;
					batch.AddMesh(data, indices);
				}
			}

			if (createNew)
			{
				Batch batch = new Batch(glStates, attribPointers, count, program, textures);
				Batches.Add(batch);
				batch.AddMesh(data, indices);
			}
		}

		/// <summary>
		/// Adds <see cref="Mesh"/> to new or existing <see cref="StaticBatch"/>.
		/// </summary>
		/// <param name="data">Vertex data.</param>
		/// <param name="indices">Vertex indices.</param>
		/// <param name="attribPointers">List of <see cref="AttribPointer"/> that represents vertex data layout.</param>
		/// <param name="count">Count of vertices.</param>
		/// <param name="program">Shader handle used by mesh.</param>
		/// <param name="textures">Texture handle used by mesh.</param>
		public void AddMesh(byte[] data, uint[] indices, List<AttribPointer> attribPointers, int count, int program, params int[] textures)
		{
			bool createNew = true;

			foreach (Batch batch in Batches)
			{
				if (batch.MeshSize == count && batch.AttribPointers.Count == 0 && batch.ProgramHandle == program && batch.TextureHandles.SequenceEqual(textures))
				{
					createNew = false;
					batch.AddMesh(data, indices);
				}
			}

			if (createNew)
			{
				Batch batch = new Batch(attribPointers, count, program, textures);
				Batches.Add(batch);
				batch.AddMesh(data, indices);
			}
		}
	}
}
