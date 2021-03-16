// <copyright file="IGLState.cs" company="BroMandarin">
// Copyright (c) BroMandarin. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenTK.Graphics.OpenGL;

namespace MandarinBatcher
{
	/// <summary>
	/// Custom OpenGL state to be overriden by <see cref="StaticBatch"/>.
	/// </summary>
	public interface IGLState
	{
		/// <summary>
		/// Gets OpenGL state.
		/// </summary>
		public All State { get; }

		/// <summary>
		/// Gets state value.
		/// </summary>
		public All Value { get; }

		/// <summary>
		/// Sets State to Value.
		/// </summary>
		public void Call();

		/// <summary>
		/// Resets State to it's default value.
		/// </summary>
		public void Default();
	}
}
