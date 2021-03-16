// <copyright file="GLStateMachine.cs" company="BroMandarin">
// Copyright (c) BroMandarin. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace MandarinBatcher
{
	/// <summary>
	/// A GLStateMachine class.
	/// </summary>
	public static class GLStateMachine
	{
		/// <summary>
		/// Gets list of IGLState ofjects.
		/// </summary>
		public static List<IGLState> GLStates { get; } = new List<IGLState>();

		/// <summary>
		/// Adds IGLState to GLStates.
		/// </summary>
		/// <param name="state">IGLState to be added.</param>
		public static void AddState(IGLState state)
		{
			GLStates.Add(state);
		}

		/// <summary>
		/// Removes IGLState from GLStates.
		/// </summary>
		/// <param name="state">IGLState to be removed.</param>
		public static void RemoveState(IGLState state)
		{
			GLStates.Remove(state);
		}
	}
}
