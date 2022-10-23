//
//  ICloneable{T}.cs
//
//  Authors:
//       Justin Chase <justin@thebackroom.app>
//       &
//       Municipal Drew <drew@wheatleythecat.com>
//
//  Copyright ©️ 2022 2022 Justin Chase
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace System
{
    /// <summary>Clones the object</summary>
    /// <typeparam name="TSelf">The class' name</typeparam>
    public interface ICloneable<TSelf> where TSelf : ICloneable<TSelf>
    {
        /// <summary>Clones the object</summary>
        /// <returns>The cloned object</returns>
        TSelf Clone();
    }
}
