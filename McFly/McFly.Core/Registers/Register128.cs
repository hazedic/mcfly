﻿// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-07-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-07-2018
// ***********************************************************************
// <copyright file="Register128.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Core.Registers
{
    /// <summary>
    ///     Class Register.
    /// </summary>
    public partial class Register
    {
        /// <summary>
        ///     Gets the XMM0.
        /// </summary>
        /// <value>The XMM0.</value>
        public static Xmm0Register Xmm0 { get; } = new Xmm0Register();

        /// <summary>
        ///     Gets the XMM1.
        /// </summary>
        /// <value>The XMM1.</value>
        public static Xmm1Register Xmm1 { get; } = new Xmm1Register();

        /// <summary>
        ///     Gets the XMM10.
        /// </summary>
        /// <value>The XMM10.</value>
        public static Xmm10Register Xmm10 { get; } = new Xmm10Register();

        /// <summary>
        ///     Gets the XMM11.
        /// </summary>
        /// <value>The XMM11.</value>
        public static Xmm11Register Xmm11 { get; } = new Xmm11Register();

        /// <summary>
        ///     Gets the XMM12.
        /// </summary>
        /// <value>The XMM12.</value>
        public static Xmm12Register Xmm12 { get; } = new Xmm12Register();

        /// <summary>
        ///     Gets the XMM13.
        /// </summary>
        /// <value>The XMM13.</value>
        public static Xmm13Register Xmm13 { get; } = new Xmm13Register();

        /// <summary>
        ///     Gets the XMM14.
        /// </summary>
        /// <value>The XMM14.</value>
        public static Xmm14Register Xmm14 { get; } = new Xmm14Register();

        /// <summary>
        ///     Gets the XMM15.
        /// </summary>
        /// <value>The XMM15.</value>
        public static Xmm15Register Xmm15 { get; } = new Xmm15Register();

        /// <summary>
        ///     Gets the XMM2.
        /// </summary>
        /// <value>The XMM2.</value>
        public static Xmm2Register Xmm2 { get; } = new Xmm2Register();

        /// <summary>
        ///     Gets the XMM3.
        /// </summary>
        /// <value>The XMM3.</value>
        public static Xmm3Register Xmm3 { get; } = new Xmm3Register();

        /// <summary>
        ///     Gets the XMM4.
        /// </summary>
        /// <value>The XMM4.</value>
        public static Xmm4Register Xmm4 { get; } = new Xmm4Register();

        /// <summary>
        ///     Gets the XMM5.
        /// </summary>
        /// <value>The XMM5.</value>
        public static Xmm5Register Xmm5 { get; } = new Xmm5Register();

        /// <summary>
        ///     Gets the XMM6.
        /// </summary>
        /// <value>The XMM6.</value>
        public static Xmm6Register Xmm6 { get; } = new Xmm6Register();

        /// <summary>
        ///     Gets the XMM7.
        /// </summary>
        /// <value>The XMM7.</value>
        public static Xmm7Register Xmm7 { get; } = new Xmm7Register();

        /// <summary>
        ///     Gets the XMM8.
        /// </summary>
        /// <value>The XMM8.</value>
        public static Xmm8Register Xmm8 { get; } = new Xmm8Register();

        /// <summary>
        ///     Gets the XMM9.
        /// </summary>
        /// <value>The XMM9.</value>
        public static Xmm9Register Xmm9 { get; } = new Xmm9Register();

        /// <summary>
        ///     Class Xmm0Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm0Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm0";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm10Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm10Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm10";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm11Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm11Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm11";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm12Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm12Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm12";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm13Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm13Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm13";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm14Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm14Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm14";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm15Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm15Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm15";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm1Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm1Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm1";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm2Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm2Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm2";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm3Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm3Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm3";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm4Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm4Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm4";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm5Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm5Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm5";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm6Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm6Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm6";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm7Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm7Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm7";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm8Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm8Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm8";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm9Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm9Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm9";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }
    }
}