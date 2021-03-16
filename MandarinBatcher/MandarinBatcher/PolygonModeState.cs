// <copyright file="PolygonModeState.cs" company="BroMandarin">
// Copyright (c) BroMandarin. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenTK.Graphics.OpenGL;

namespace MandarinBatcher
{
	public struct PolygonModeState : IGLState
	{
		public PolygonModeState(PolygonMode value, MaterialFace materialFace)
		{
			State = All.PolygonMode;
			Value = (All)value;
			MaterialFace = materialFace;
		}

		public All State { get; }

		public All Value { get; }

		public MaterialFace MaterialFace { get; }

		public void Call()
		{
			GL.PolygonMode(MaterialFace, (PolygonMode)Value);
		}

		public void Default()
		{
			GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
		}
	}
}
