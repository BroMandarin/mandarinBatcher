// <copyright file="AttribPointer.cs" company="BroMandarin">
// Copyright (c) BroMandarin. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenTK.Graphics.OpenGL;

namespace MandarinBatcher
{
	/// <summary>
	/// Represents a single attribute pointer.
	/// </summary>
	public struct AttribPointer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttribPointer"/> struct.
		/// </summary>
		/// <param name="index">Specifies the index of the generic vertex attribute to be modified.</param>
		/// <param name="size">Specifies the number of components per generic vertex attribute. Must be 1, 2, 3, 4. Additionally, the symbolic constant Bgra is accepted by glVertexAttribPointer. The initial value is 4.</param>
		/// <param name="vertexAttribPointerType">Specifies the data type of each component in the array. The symbolic constants Byte, UnsignedByte, Short, UnsignedShort, Int, and UnsignedInt are accepted by glVertexAttribPointer and glVertexAttribIPointer. Additionally HalfFloat, Float, Double, Fixed, Int2101010Rev, UnsignedInt2101010Rev and UnsignedInt10F11F11FRev are accepted by glVertexAttribPointer. Double is also accepted by glVertexAttribLPointer and is the only token accepted by the type parameter for that function. The initial value is Float.</param>
		/// <param name="normalized">For glVertexAttribPointer, specifies whether fixed-point data values should be normalized (True) or converted directly as fixed-point values (False) when they are accessed.</param>
		/// <param name="stride">Specifies the byte offset between consecutive generic vertex attributes. If stride is 0, the generic vertex attributes are understood to be tightly packed in the array. The initial value is 0.</param>
		/// <param name="offset">Specifies the first component of the first generic vertex attribute in the array in the data store of the buffer currently bound to the ArrayBuffer target. The initial value is 0.</param>
		public AttribPointer(int index, int size, VertexAttribPointerType vertexAttribPointerType, bool normalized, int stride, int offset)
		{
			Index = index;
			Size = size;
			VertexAttribPointerType = vertexAttribPointerType;
			Normalized = normalized;
			Stride = stride;
			Offset = offset;
		}

		/// <summary>
		/// Gets index of the vertex attribute.
		/// </summary>
		public int Index { get; }

		/// <summary>
		/// Gets size of the vertex attribute.
		/// </summary>
		public int Size { get; }

		/// <summary>
		/// Gets VertexAttribPointerType of the vertex attribute.
		/// </summary>
		public VertexAttribPointerType VertexAttribPointerType { get; }

		/// <summary>
		/// Gets a value indicating whether vertex attribute is normalized.
		/// </summary>
		public bool Normalized { get; }

		/// <summary>
		/// Gets stride of the vertex attribute.
		/// </summary>
		public int Stride { get; }

		/// <summary>
		/// Gets offset of the vertex attribute.
		/// </summary>
		public int Offset { get; }
	}
}
